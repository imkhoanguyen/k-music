using Music.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class PlaylistSongRepository : Repository<PlaylistSong>, IPlaylistSongRepository
    {
        private readonly MusicContext _context;

        public PlaylistSongRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<PlaylistSong>> GetAllAsync(Expression<Func<PlaylistSong, bool>>? expression = null, bool tracked = false)
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
