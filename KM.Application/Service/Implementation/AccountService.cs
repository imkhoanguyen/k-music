using KM.Application.DTOs.Accounts;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using KM.Domain.Exceptions;

namespace KM.Application.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unit;

        public AccountService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<bool> CheckLikePlaylistAsync(LikePlaylistDto dto)
        {
            if (await _unit.LikePlaylist.ExistsAsync(lp => lp.UserId == dto.UserId && lp.PlaylistId == dto.PlaylistId) == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckLikeSingerAsync(LikeSingerDto dto)
        {
            if (await _unit.LikeSinger.ExistsAsync(ls => ls.UserId == dto.UserId && ls.SingerId == dto.SingerId) == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckLikeSongAsync(LikeSongDto dto)
        {
            if (await _unit.LikeSong.ExistsAsync(ls => ls.UserId == dto.UserId && ls.SongId == dto.SongId) == true)
            {
                return true;
            }
            return false;
        }

        public async Task LikePlaylistAsync(LikePlaylistDto dto)
        {
            if (await _unit.Playlist.ExistsAsync(p => p.Id == dto.PlaylistId) == false)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if(await CheckLikePlaylistAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích danh sách phát này rồi");
            }

            var entity = new LikePlaylist
            {
                PlaylistId = dto.PlaylistId,
                UserId = dto.UserId,
            };

            await _unit.LikePlaylist.AddAsync(entity);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích danh sách phát");
            }
        }

        public async Task LikeSingerAsync(LikeSingerDto dto)
        {
            if (await _unit.Singer.ExistsAsync(s => s.Id == dto.SingerId) == false)
            {
                throw new NotFoundException("Không tìm thấy ca sĩ");
            }

            if (await CheckLikeSingerAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích ca sĩ này rồi");
            }

            var entity = new LikeSinger
            {
                SingerId = dto.SingerId,
                UserId = dto.UserId,
            };

            await _unit.LikeSinger.AddAsync(entity);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích ca sĩ");
            }
        }

        public async Task LikeSongAsync(LikeSongDto dto)
        {
            if(await _unit.Song.ExistsAsync(s => s.Id == dto.SongId) == false)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }

            if (await CheckLikeSongAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích bài hát này rồi");
            }

            var entity = new LikeSong
            {
                SongId = dto.SongId,
                UserId = dto.UserId,
            };

            await _unit.LikeSong.AddAsync(entity);

            if(!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích bài hát");
            }
        }

        public async Task UnlikePlaylistAsync(LikePlaylistDto dto)
        {
            var entity = await _unit.LikePlaylist.GetAsync(lp => lp.UserId == dto.UserId && lp.PlaylistId == dto.PlaylistId);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát đã thích");
            }

            _unit.LikePlaylist.Remove(entity);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích danh sách phát thất bại");
            }
        }

        public async Task UnlikeSingerAsync(LikeSingerDto dto)
        {
            var entity = await _unit.LikeSinger.GetAsync(ls => ls.UserId == dto.UserId && ls.SingerId == dto.SingerId);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy ca sĩ đã thích");
            }

            _unit.LikeSinger.Remove(entity);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích ca sĩ thất bại");
            }
        }

        public async Task UnlikeSongAsync(LikeSongDto dto)
        {
            var entity = await _unit.LikeSong.GetAsync(ls => ls.UserId == dto.UserId && ls.SongId == dto.SongId);
            if(entity == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát đã thích");
            }

            _unit.LikeSong.Remove(entity);
            if(!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích bài hát thất bại");
            }
        }
    }
}
