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

        public async Task<bool> CheckLikeSongAsync(LikeSongDto dto)
        {
            if (await _unit.LikeSong.ExistsAsync(ls => ls.UserId == dto.UserId && ls.SongId == dto.SongId) == true)
            {
                return true;
            }
            return false;
        }

        public async Task LikeSongAsync(LikeSongDto dto)
        {
            if(await _unit.Song.ExistsAsync(s => s.Id == dto.SongId) == false)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
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
