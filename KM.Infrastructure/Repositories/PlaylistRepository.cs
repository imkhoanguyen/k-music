using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KM.Infrastructure.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly MusicContext _context;

        public PlaylistRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Playlist>> GetAllAsync(PlaylistParams prm, bool tracked = false)
        {
            var query = tracked ? _context.Playlist.AsQueryable() : 
                _context.Playlist.AsNoTracking().AsQueryable();

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
                    "play" => query.OrderBy(p => p.PlayCount),
                    "play_desc" => query.OrderByDescending(p => p.PlayCount),
                    _ => query.OrderByDescending(p => p.Id)
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }
    }
}
