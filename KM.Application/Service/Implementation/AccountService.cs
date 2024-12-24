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

        public async Task LikeSongAsync(AddLikeSongDto dto)
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
    }
}
