using Music.Core.DTOs.Accounts;
using Music.Core.DTOs.Playlists;
using Music.Core.DTOs.Singers;
using Music.Core.DTOs.Songs;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Service.Interfaces
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
