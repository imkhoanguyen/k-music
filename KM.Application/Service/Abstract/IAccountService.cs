using KM.Application.DTOs.Accounts;

namespace KM.Application.Service.Abstract
{
    public interface IAccountService
    {
        Task LikeSongAsync(AddLikeSongDto dto);
    }
}
