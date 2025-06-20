using Music.Core.DTOs.Accounts;
using Music.Core.DTOs.Playlists;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;
using System.Linq.Expressions;

namespace Music.Core.Service.Interfaces
{
    public interface IPlaylistService
    {
        Task<PagedList<PlaylistDto>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null);
        Task<PlaylistDto> CreateAsync(PlaylistCreateDto dto);
        Task<PlaylistDetailDto> AddSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDto> UpdateAsync(int playlistId, PlaylistUpdateDto dto);
        Task DeleteAsync(Expression<Func<Playlist, bool>> expression);
        Task DeleteSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDetailDto> GetAsync(Expression<Func<Playlist, bool>> expression);
        Task<PlaylistDto> CreateAutoAsync(PlaylistCreateAutoDto dto);
        Task<PagedList<QuickViewPlaylistResponse>> GetQuickViewMyPlaylistAsync(PlaylistParams prm, QuickViewPlaylistRequest request);
        Task<bool> AddOrRemoveSong(QuickAddSongToPlaylistRequest request); // false = delete, true = add
        Task<PlaylistDetailDto1> GetAsync(Expression<Func<Playlist, bool>> expression, string userId);
    }
}
