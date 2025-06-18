using KM.Application.DTOs.Accounts;
using KM.Application.DTOs.Playlists;
using KM.Application.DTOs.Singers;
using KM.Application.DTOs.Songs;
using KM.Application.Parameters;
using KM.Application.Utilities;

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
        Task<PagedList<SongDto>> GetSongLiked(SongParams prm, string userId);
        Task<PagedList<PlaylistDto>> GetPlaylistLiked(PlaylistParams prm, string userId);
        Task<PagedList<SingerDto>> GetSingerLiked(SingerParams prm, string userId);
    }
}
