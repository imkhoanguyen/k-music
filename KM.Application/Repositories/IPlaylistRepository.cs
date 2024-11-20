using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<PagedList<Playlist>> GetAllAsync(PlaylistParams prm, bool tracked = false);
    }
}
