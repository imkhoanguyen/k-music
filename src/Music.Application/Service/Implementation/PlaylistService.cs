using Music.Application.Abstract;
using Music.Application.DTOs.Accounts;
using Music.Application.DTOs.Playlists;
using Music.Application.DTOs.Songs;
using Music.Application.Mappers;
using Music.Application.Parameters;
using Music.Application.Repositories;
using Music.Application.Service.Abstract;
using Music.Application.Utilities;
using Music.Domain.Entities;
using Music.Domain.Exceptions;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Service.Implementation
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

        public async Task<bool> AddOrRemoveSong(QuickAddSongToPlaylistRequest request)
        {
            var ps = await _unit.PlaylistSong.GetAsync(ps => ps.SongId == request.SongId && ps.PlaylistId == request.PlaylistId);
            bool flag = false;


            if(ps != null)
            {
                _unit.PlaylistSong.Remove(ps);
                flag = false;
            } else
            {
                var newPs = new PlaylistSong(request.PlaylistId, request.SongId);
                await _unit.PlaylistSong.AddAsync(newPs);
                flag = true;
            }

            if(await _unit.CompleteAsync())
            {
                return flag;
            }

            throw new BadRequestException("Xảy ra lỗi khi thêm hoặc xóa bài hát khỏi danh sách phát");
        }

        public async Task<PlaylistDetailDto> AddSongAsync(int playlistId, List<int> songIdList)
        {
            if (!await _unit.Playlist.ExistsAsync(p => p.Id == playlistId))
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if (songIdList.Count < 1)
            {
                throw new BadRequestException("Danh sách bài hát phải lớn hơn hoặc bằng 1");
            }

            var currentPlaylistSong = await _unit.PlaylistSong.GetAllAsync(ps => ps.PlaylistId == playlistId);
            var songListAdd = songIdList.Select(songId => new PlaylistSong(playlistId, songId))
                .Except(currentPlaylistSong.Select(ps => new PlaylistSong(ps.PlaylistId, ps.SongId)));

            await _unit.PlaylistSong.AddRangeAsync(songListAdd);

            if (await _unit.CompleteAsync())
            {
                var playlist = await _unit.Playlist.GetDetailAsync(p => p.Id == playlistId);
                return new PlaylistDetailDto
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    Created = playlist.Created,
                    Updated = playlist.Updated,
                    ImgUrl = playlist.ImgUrl,
                    IsPublic = playlist.IsPublic,
                    UserName = playlist.AppUser?.UserName ?? string.Empty,
                    SongList = playlist.PlaylistSongs.Select(ps => SongMapper.EntityToSongDto(ps.Song!)).ToList(),
                };
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
                var playlistToReturn = await _unit.Playlist.GetAsync(p => p.Id == playlist.Id);
                return PlaylistMapper.EntityToPlaylistDto(playlistToReturn!);
            }
            throw new BadRequestException("Có lỗi xảy ra khi thêm danh sách phát");
        }

        public async Task<PlaylistDto> CreateAutoAsync(PlaylistCreateAutoDto dto)
        {
            if(dto.Count < 1)
            {
                throw new BadRequestException("Số lượng bài hát phải lớn hơn hoặc bằng 1");
            }

            var songList = await _unit.Song.GetAllAsync();

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
                var playlistToReturn = await _unit.Playlist.GetAsync(p => p.Id == playlist.Id);
                return PlaylistMapper.EntityToPlaylistDto(playlistToReturn!);
            }

            throw new BadRequestException("Xảy ra lỗi khi tạo danh sách phát tự động");
        }

        public async Task DeleteAsync(Expression<Func<Playlist, bool>> expression)
        {
            var playlist = await _unit.Playlist.GetAsync(expression, true);
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

        public async Task<PagedList<PlaylistDto>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null)
        {
            var pagedList = await _unit.Playlist.GetAllAsync(prm, expression);

            var playlistDtos = pagedList.Select(PlaylistMapper.EntityToPlaylistDto).ToList();

            return new PagedList<PlaylistDto>(playlistDtos, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
        }

        public async Task<PlaylistDetailDto> GetAsync(Expression<Func<Playlist, bool>> expression)
        {
            var playlist  = await _unit.Playlist.GetDetailAsync(expression, false);
            if (playlist == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }

            return new PlaylistDetailDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Created = playlist.Created,
                Updated = playlist.Updated,
                ImgUrl = playlist.ImgUrl,
                IsPublic = playlist.IsPublic,
                UserName = playlist.AppUser?.UserName ?? string.Empty,
                SongList = playlist.PlaylistSongs.Select(ps => SongMapper.EntityToSongDto(ps.Song!)).ToList(),
            };
        }

        public async Task<PlaylistDetailDto1> GetAsync(Expression<Func<Playlist, bool>> expression, string userId)
        {
            var playlist = await _unit.Playlist.GetDetailAsync(expression, false);
            if (playlist == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }

            var currentSongList = playlist.PlaylistSongs.Select(ps => SongMapper.EntityToSongDto(ps.Song!)).ToList();
            var newSongList = new List<SongHaveLikeDto>();

            foreach(var song in currentSongList)
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

            return new PlaylistDetailDto1
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Created = playlist.Created,
                Updated = playlist.Updated,
                ImgUrl = playlist.ImgUrl,
                IsPublic = playlist.IsPublic,
                UserName = playlist.AppUser?.UserName ?? string.Empty,
                SongList = newSongList,
            };
        }

        public async Task<PagedList<QuickViewPlaylistResponse>> GetQuickViewMyPlaylistAsync(PlaylistParams prm, QuickViewPlaylistRequest request)
        {
            if (request.SongId < 1)
            {
                throw new BadRequestException("Bài hát không tồn tại vui lòng thử lại sau");
            }

            var pagedList = await GetAllAsync(prm, p => p.UserId == request.UserId);

            var quickViewPlaylists = new List<QuickViewPlaylistResponse>();

            foreach (var playlist in pagedList)
            {
                var response = new QuickViewPlaylistResponse
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    ImgUrl = playlist.ImgUrl,
                    IsPublic = playlist.IsPublic
                };

                if (await _unit.PlaylistSong.ExistsAsync(ps => ps.SongId == request.SongId && ps.PlaylistId == playlist.Id) == true)
                {
                    response.HaveSong = true;
                }
                else
                {
                    response.HaveSong = false;
                }

                quickViewPlaylists.Add(response);
            }

            return new PagedList<QuickViewPlaylistResponse>(quickViewPlaylists, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
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
                var playlistToReturn = await _unit.Playlist.GetAsync(p => p.Id == playlist.Id);
                return PlaylistMapper.EntityToPlaylistDto(playlistToReturn!);
            }

            throw new BadRequestException("Xảy ra lỗi khi cập nhật danh sách phát");
        }
    }
}
