using KM.Application.DTOs.Singers;
using KM.Application.DTOs.Songs;
using KM.Application.Interfaces;
using KM.Application.Mappers;
using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Domain.Exceptions;
using System.Linq.Expressions;

namespace KM.Application.Service.Implementation
{
    public class SingerService : ISingerService
    {
        private readonly IUnitOfWork _unit;
        private readonly ICloudinaryService _cloudinaryService;

        public SingerService(IUnitOfWork unit, ICloudinaryService cloudinaryService)
        {
            _unit = unit;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<SingerDto> CreateSingerAsync(SingerCreateDto singerCreateDto)
        {
            var result = await _cloudinaryService.AddImageAsync(singerCreateDto.ImgFile);
            if (result.Error != null) throw new BadRequestException(result.Error);

            var singer = SingerMapper.SingerCreateDtoToEntity(singerCreateDto);
            singer.ImgUrl = result.Url;
            singer.PublicId = result.PublicId;

            await _unit.Singer.AddAsync(singer);

            if (await _unit.CompleteAsync())
            {
                return SingerMapper.EntityToSingerDto(singer);
            }

            throw new BadRequestException("Đã xảy ra lỗi khi thêm ca sĩ");
        }

        public async Task DeleteAsync(Expression<Func<Singer, bool>> expression)
        {
            var singer = await _unit.Singer.GetAsync(expression);
            if (singer == null) throw new NotFoundException("Không tìm thấy ca sĩ");

            // remove img on cloudinary
            if (singer.PublicId != null)
            {
                var result = await _cloudinaryService.DeleteFileAsync(singer.PublicId);
                if (result.Error != null) throw new BadRequestException(result.Error);
            }

            _unit.Singer.Remove(singer);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Đã xảy ra lỗi khi xóa ca sĩ");
            }
        }

        public async Task<PagedList<SingerDto>> GetAllAsync(SingerParams prm, Expression<Func<Singer, bool>>? expression = null)
        {
            var singers = await _unit.Singer.GetAllAsync(prm, expression);

            var singerDtos = singers.Select(SingerMapper.EntityToSingerDto);

            return new PagedList<SingerDto>(singerDtos, singers.TotalCount, singers.CurrentPage, singers.PageSize);
        }

        public async Task<IEnumerable<SingerDto>> GetAllAsync()
        {
            var singers = await _unit.Singer.GetAllAsync();

            return singers.Select(SingerMapper.EntityToSingerDto);
        }

        public async Task<SingerDto> GetAsync(Expression<Func<Singer, bool>> expression)
        {
            var singer = await _unit.Singer.GetAsync(expression);

            if (singer == null) throw new NotFoundException("Ca sĩ không tồn tại");

            return SingerMapper.EntityToSingerDto(singer);
        }

        public async Task<IEnumerable<string>> GetLocationsAsync()
        {
            var locations = await _unit.Singer.GetLocationsAsync();
            return locations;
        }

        public async Task<SingerDetailDto> GetSingerDetail(Expression<Func<Singer, bool>> expression, SongParams prm)
        {
            var singer = await _unit.Singer.GetAsync(expression);
            if (singer == null)
                throw new NotFoundException("Không tìm thấy ca sĩ");
            var songs = await _unit.Song.GetAllAsync(prm, s => s.SongSingers.Any(sg => sg.SingerId == singer.Id));
            var songDtos = songs.Select(SongMapper.EntityToSongDto);
            return new SingerDetailDto
            {
                Id = singer.Id,
                Name = singer.Name,
                Gender = singer.Gender.ToString(),
                Introduction = singer.Introduction,
                Location = singer.Location,
                ImgUrl = singer.ImgUrl,
                SongList = new PagedList<SongDto>(songDtos, songs.TotalCount, songs.CurrentPage, songs.PageSize)
            };
        }

        public async Task<SingerDetailDto1> GetSingerDetail(Expression<Func<Singer, bool>> expression, SongParams prm, string userId)
        {
            var singer = await _unit.Singer.GetAsync(expression);
            if (singer == null)
                throw new NotFoundException("Không tìm thấy ca sĩ");
            var songs = await _unit.Song.GetAllAsync(prm, s => s.SongSingers.Any(sg => sg.SingerId == singer.Id));
            var songDtos = songs.Select(SongMapper.EntityToSongDto);
            var newSongList = new List<SongHaveLikeDto>();

            foreach (var song in songDtos)
            {
                var dto = new SongHaveLikeDto
                {
                    Id = song.Id,
                    Name = song.Name,
                    ImgUrl = song.ImgUrl,
                    SongUrl = song.SongUrl,
                    Introduction = song.Introduction,
                    Lyric = song.Lyric,
                    Created = song.Created,
                    Updated = song.Updated,
                    Singers = song.Singers,
                    Genres = song.Genres,
                    IsVip = song.IsVip
                };

                dto.Liked = await _unit.LikeSong.ExistsAsync(ls => ls.UserId == userId && ls.SongId == dto.Id);
                newSongList.Add(dto);
            }

            return new SingerDetailDto1
            {
                Id = singer.Id,
                Name = singer.Name,
                Gender = singer.Gender.ToString(),
                Introduction = singer.Introduction,
                Location = singer.Location,
                ImgUrl = singer.ImgUrl,
                SongList = new PagedList<SongHaveLikeDto>(newSongList, songs.TotalCount, songs.CurrentPage, songs.PageSize)
            };
        }

        public async Task<SingerDto> UpdateSingerAsync(int id, SingerUpdateDto singerUpdateDto)
        {

            if (id != singerUpdateDto.Id)
            {
                throw new BadRequestException("Id không khớp. Không thể cập nhật");
            }

            var existingSinger = await _unit.Singer.GetAsync(s => s.Id == id);

            if (existingSinger == null)
            {
                throw new NotFoundException("Không tìm thấy ca sĩ");
            }

            var singer = SingerMapper.SingerUpdateDtoToEntity(singerUpdateDto);

            // Add new photo if available (cloudinary)
            if (singerUpdateDto.ImgFile != null)
            {
                var resultUpload = await _cloudinaryService.AddImageAsync(singerUpdateDto.ImgFile);
                if (resultUpload.Error != null)
                    throw new BadRequestException(resultUpload.Error);

                // update ImgUrl & PublicId when upload successed
                singer.ImgUrl = resultUpload.Url;
                singer.PublicId = resultUpload.PublicId;

                // Remove after add new photo (cloudinary)
                var resultDelete = await _cloudinaryService.DeleteFileAsync(existingSinger.PublicId);
                if (resultDelete.Error != null)
                    throw new BadRequestException(resultDelete.Error);

                // update all property 
                _unit.Singer.Update(singer);
            }
            else
            {
                await _unit.Singer.UpdateNoPhotoAsync(singer); // update without imgUrl & publicId
            }

            if (await _unit.CompleteAsync())
            {
                var singerToReturn = await _unit.Singer.GetAsync(s => s.Id == singer.Id);
                return SingerMapper.EntityToSingerDto(singerToReturn);
            }

            throw new BadRequestException("Đã xảy ra lỗi khi cập nhật ca sĩ");
        }
    }
}
