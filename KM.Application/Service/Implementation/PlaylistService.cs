using KM.Application.DTOs.Playlists;
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
    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unit;
        private readonly ICloudinaryService _cloudinaryService;

        public PlaylistService(IUnitOfWork unit, ICloudinaryService cloudinaryService)
        {
            _unit = unit;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<PlaylistDto> AddSongAsync(int playlistId, List<int> songIdList)
        {
            if (!await _unit.Playlist.ExistsAsync(p => p.Id == playlistId))
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if (songIdList.Count < 1)
            {
                throw new BadRequestException("Danh sách bài hát phải lớn hơn hoặc bằng 1");
            }

            var currentPlaylistSong = await _unit.PlaylistSong.GetPlaylistSongsAsync(ps => ps.PlaylistId == playlistId);
            var songListAdd = songIdList.Select(songId => new PlaylistSong(playlistId, songId))
                .Except(currentPlaylistSong.Select(ps => new PlaylistSong(ps.PlaylistId, ps.SongId)));

            await _unit.PlaylistSong.AddRangeAsync(songListAdd);

            if (await _unit.CompleteAsync())
            {
                var playList = await _unit.Playlist.GetAsync(p => p.Id == playlistId);
                return PlaylistMapper.EntityToPlaylistDto(playList!);
            }

            throw new BadRequestException("Xảy ra lỗi khi thêm bài hát vào danh sách phát");
        }

        public async Task<PlaylistDto> CreateAsync(PlaylistCreateDto dto)
        {
            var result = await _cloudinaryService.AddImageAsync(dto.ImgFile);
            if (result.Error != null)
            {
                throw new BadRequestException(result.Error);
            }

            var playlist = PlaylistMapper.PlaylistCreateDtoEntity(dto);
            playlist.ImgUrl = result.Url;
            playlist.PublicId = result.PublicId;

            if (dto.SongList.Count > 0)
            {
                foreach (var songId in dto.SongList)
                {
                    var playlistSong = new PlaylistSong(playlist.Id, songId);
                    playlist.PlaylistSongs.Add(playlistSong);
                }
            }

            await _unit.Playlist.AddAsync(playlist);
            if (await _unit.CompleteAsync())
            {
                return PlaylistMapper.EntityToPlaylistDto(playlist);
            }
            throw new BadRequestException("Có lỗi xảy ra khi thêm danh sách phát");
        }

        public async Task<PlaylistDto> CreateAutoAsync(PlaylistCreateAutoDto dto)
        {
            if(dto.Count < 1)
            {
                throw new BadRequestException("Số lượng bài hát phải lớn hơn hoặc bằng 1");
            }

            var songList = await _unit.Song.GetAllAsync(false);

            // select 
            if (dto.SelectedGenres.Count > 0)
            {
                songList = songList.Where(s => s.SongGenres.Any(sg => dto.SelectedGenres.Contains(sg.GenreId)));
            }

            // select 
            if(dto.SelectedSingers.Count > 0)
            {
                songList = songList.Where(s => s.SongSingers.Any(ss => dto.SelectedSingers.Contains(ss.SingerId)));
            }


            // get ramdom song
            var ramdomSongs = songList.OrderBy(_ => Guid.NewGuid())
                .Take(dto.Count).ToList();


            // upload img
            var result = await _cloudinaryService.AddImageAsync(dto.ImgFile);
            if (result.Error != null)
            {
                throw new BadRequestException(result.Error);
            }

            // define new playlist
            var playlist = new Playlist
            {
                Name = dto.Name,
                UserId = dto.UserId,
            };

            // path value to playlist
            playlist.ImgUrl = result.Url;
            playlist.PublicId = result.PublicId;

            // define playlistsongs
            var playlistSongs = ramdomSongs.Select(s => new PlaylistSong(playlist.Id, s.Id));
            playlist.PlaylistSongs.AddRange(playlistSongs);

            await _unit.Playlist.AddAsync(playlist);

            if(await _unit.CompleteAsync())
            {
               return PlaylistMapper.EntityToPlaylistDto(playlist);
            }

            throw new BadRequestException("Xảy ra lỗi khi tạo danh sách phát tự động");
        }

        public async Task DeleteAsync(Expression<Func<Playlist, bool>> expression)
        {
            var playlist = await _unit.Playlist.GetAsync(expression);
            if (playlist == null)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            // remove img on cloudinary
            var result = await _cloudinaryService.DeleteFileAsync(playlist.PublicId);
            if (result.Error != null)
            {
                throw new BadRequestException(result.Error);
            }

            _unit.Playlist.Remove(playlist);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Xảy ra lỗi khi xóa danh sách phát");
            }
        }

        public async Task DeleteSongAsync(int playlistId, List<int> songIdList)
        {
            if (!await _unit.Playlist.ExistsAsync(p => p.Id == playlistId))
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if (songIdList.Count < 1)
            {
                throw new BadRequestException("Danh sách bài hát phải lớn hơn hoặc bằng 1");
            }

            var playlistSongToRemove = songIdList.Select(songId => new PlaylistSong(playlistId, songId));

            _unit.PlaylistSong.DeleteRange(playlistSongToRemove);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Đã xảy ra lỗi khi xóa bài hát khỏi danh sách phát");
            }
        }

        public async Task<PagedList<PlaylistDto>> GetAllAsync(PlaylistParams prm, bool tracked = false)
        {
            var pagedList = await _unit.Playlist.GetAllAsync(prm, tracked);

            var playlistDtos = pagedList.Select(PlaylistMapper.EntityToPlaylistDto).ToList();

            return new PagedList<PlaylistDto>(playlistDtos, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
        }

        public async Task<PlaylistDto> GetAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false)
        {
            var playlist  = await _unit.Playlist.GetAsync(expression, tracked);
            if (playlist == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }
            return PlaylistMapper.EntityToPlaylistDto(playlist);
        }

        public async Task<PlaylistDto> UpdateAsync(int playlistId, PlaylistUpdateDto dto)
        {
            if(playlistId != dto.Id)
            {
                throw new BadRequestException("Không thể cập nhật danh sách phát. Hãy thử lái sau");
            }

            var playlist = await _unit.Playlist.GetAsync(p => p.Id == dto.Id, true);

            if(playlist == null)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if (dto.ImgFile != null)
            {
                // delete img in cloudinary
                var resultDelete = await _cloudinaryService.DeleteFileAsync(playlist.PublicId);
                if (resultDelete.Error != null)
                {
                    throw new BadRequestException(resultDelete.Error);
                }

                var resultAdd = await _cloudinaryService.AddImageAsync(dto.ImgFile);
                if (resultAdd.Error != null)
                {
                    throw new BadImageFormatException(resultAdd.Error);
                }

                playlist.PublicId = resultAdd.PublicId;
                playlist.ImgUrl = resultAdd.Url;
            }

            playlist.Name = dto.Name;
            playlist.IsPublic = dto.IsPublic;
            playlist.Updated = DateTime.Now;

            if(await _unit.CompleteAsync())
            {
                return PlaylistMapper.EntityToPlaylistDto(playlist);
            }

            throw new BadRequestException("Xảy ra lỗi khi cập nhật danh sách phát");
        }
    }
}
