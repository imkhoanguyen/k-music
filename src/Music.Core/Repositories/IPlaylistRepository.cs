using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;
using System.Linq.Expressions;

namespace Music.Core.Repositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<PagedList<Playlist>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null, bool tracked = false);
        Task<Playlist?> GetDetailAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false);
    }
}
