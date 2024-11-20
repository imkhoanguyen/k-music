using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Repositories
{
    public interface IPlaylistSongRepository : IRepository<PlaylistSong>
    {
        Task<List<PlaylistSong>> GetPlaylistSongsAsync(Expression<Func<PlaylistSong, bool>> expression,
            bool tracked = false);
    }
}
