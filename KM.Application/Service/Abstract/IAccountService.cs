using KM.Application.DTOs.Accounts;

namespace KM.Application.Service.Abstract
{
    public interface IAccountService
    {
        Task LikeSongAsync(LikeSongDto dto);
        Task UnlikeSongAsync(LikeSongDto dto);
        Task<bool> CheckLikeSongAsync(LikeSongDto dto);
    }
}
