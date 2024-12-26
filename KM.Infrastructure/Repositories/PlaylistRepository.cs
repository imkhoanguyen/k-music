using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace KM.Infrastructure.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly MusicContext _context;

        public PlaylistRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Playlist>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Playlist.AsQueryable() : 
                _context.Playlist.AsNoTracking().AsQueryable();

            query = query.Include(p => p.AppUser);

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if(!prm.UserId.IsNullOrEmpty())
            {
                query = query.Where(p => p.UserId == prm.UserId);
            }

            if(!prm.Search.IsNullOrEmpty())
            {
                query = query.Where(p => p.Name.ToLower().Contains(prm.Search.ToLower()));
            }

            if (!string.IsNullOrEmpty(prm.OrderBy))
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(p => p.Id),
                    "id_desc" => query.OrderByDescending(p => p.Id),
                    "name" => query.OrderBy(p => p.Name.ToLower()),
                    "name_desc" => query.OrderByDescending(p => p.Name.ToLower()),
                    _ => query.OrderByDescending(p => p.Id)
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }

        public async Task<Playlist?> GetDetailAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.Playlist.AsQueryable() :
                _context.Playlist.AsNoTracking().AsQueryable();

            query = query
                .Include(p => p.AppUser)
                .Include(p => p.LikePlaylists)
                .Include(p => p.PlaylistSongs).ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.SongGenres).ThenInclude(sg => sg.Genre)
                .Include(p => p.PlaylistSongs).ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.SongSingers).ThenInclude(ss => ss.Singer);

            return await query.FirstOrDefaultAsync(expression);
        }

        public override async Task<Playlist?> GetAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.Playlist.AsQueryable() :
                _context.Playlist.AsNoTracking().AsQueryable();

            query = query.Include(p => p.AppUser);
            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
