using Music.Infrastructure.DataAccess;
using Music.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Music.Core.Entities;
using Music.Core.Utilities;
using Music.Core.Parameters;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly MusicContext _context;
        public GenreRepository(MusicContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PagedList<Genre>> GetAllAsync(GenreParams prm, bool tracked = false)
        {
            var query = tracked ? _context.Genres.AsQueryable() : _context.Genres.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(prm.Search))
            {
                query = query.Where(g => g.Name.ToLower().Contains(prm.Search.ToLower()));
            }

            if (!string.IsNullOrEmpty(prm.OrderBy))
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(g => g.Id),
                    "id_desc" => query.OrderByDescending(g => g.Id),
                    "name" => query.OrderBy(g => g.Name.ToLower()),
                    "name_desc" => query.OrderByDescending(g => g.Name.ToLower()),
                    _ => query.OrderByDescending(g => g.Id)
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }
    }
}
