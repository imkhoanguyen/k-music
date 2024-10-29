using KM.Application.DTOs.Singers;
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

        public async Task<PagedList<SingerDto>> GetAllAsync(SingerParams prm, bool tracked = false)
        {
            var singers = await _unit.Singer.GetAllAsync(prm, tracked);

            var singerDtos = singers.Select(SingerMapper.EntityToSingerDto);

            return new PagedList<SingerDto>(singerDtos, singers.TotalCount, singers.CurrentPage, singers.PageSize);
        }

        public async Task<IEnumerable<SingerDto>> GetAllAsync(bool tracked = false)
        {
            var singers = await _unit.Singer.GetAllWithoutPagingAsync(tracked);

            return singers.Select(SingerMapper.EntityToSingerDto);
        }

        public async Task<SingerDto> GetAsync(Expression<Func<Singer, bool>> expression, bool tracked = false)
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
