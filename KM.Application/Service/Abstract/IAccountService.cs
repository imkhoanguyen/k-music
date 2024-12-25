using KM.Application.DTOs.Accounts;

namespace KM.Application.Service.Abstract
{
    public interface IAccountService
    {
        Task LikeSongAsync(LikeSongDto dto);
        Task UnlikeSongAsync(LikeSongDto dto);
        Task<bool> CheckLikeSongAsync(LikeSongDto dto);

        Task LikePlaylistAsync(LikePlaylistDto dto);
        Task UnlikePlaylistAsync(LikePlaylistDto dto);
        Task<bool> CheckLikePlaylistAsync(LikePlaylistDto dto);

        Task LikeSingerAsync(LikeSingerDto dto);
        Task UnlikeSingerAsync(LikeSingerDto dto);
        Task<bool> CheckLikeSingerAsync(LikeSingerDto dto);
    }
}
