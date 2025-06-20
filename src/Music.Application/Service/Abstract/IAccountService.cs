using Music.Application.DTOs.Accounts;
using Music.Application.DTOs.Playlists;
using Music.Application.DTOs.Singers;
using Music.Application.DTOs.Songs;
using Music.Application.Parameters;
using Music.Application.Utilities;

namespace Music.Application.Service.Abstract
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
