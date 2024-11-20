using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KM.Infrastructure.Repositories
{
    public class PlaylistSongRepository : Repository<PlaylistSong>, IPlaylistSongRepository
    {
        private readonly MusicContext _context;

        public PlaylistSongRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PlaylistSong>> GetPlaylistSongsAsync(Expression<Func<PlaylistSong, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.PlaylistSongs.AsQueryable()
                : _context.PlaylistSongs.AsNoTracking().AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }
    }
}
