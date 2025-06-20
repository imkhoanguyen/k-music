using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Repositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<PagedList<Playlist>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null, bool tracked = false);
        Task<Playlist?> GetDetailAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false);
    }
}
