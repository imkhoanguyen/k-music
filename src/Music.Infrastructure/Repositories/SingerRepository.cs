using System.Diagnostics;
using System.Linq.Expressions;
using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Music.Domain.Enum;

namespace KM.Infrastructure.Repositories
{
    public class SingerRepository : Repository<Singer>, ISingerRepository
    {
        private readonly MusicContext _context;

        public SingerRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Singer>> GetAllAsync(SingerParams prm, Expression<Func<Singer, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Singers.AsQueryable() : _context.Singers.AsNoTracking().AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if (!prm.Search.IsNullOrEmpty())
                query = query.Where(s => s.Name.ToLower().Contains(prm.Search.ToLower()));

            if (!string.IsNullOrEmpty(prm.Gender))
            {
                if (Enum.TryParse<Gender>(prm.Gender, true, out var genderEnum))
                {
                    query = query.Where(s => s.Gender == genderEnum);
                }
            }

            if (!prm.Location.IsNullOrEmpty())
                query = query.Where(s => s.Location == prm.Location);

            if (!prm.OrderBy.IsNullOrEmpty())
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(s => s.Id),
                    "id_desc" => query.OrderByDescending(s => s.Id),
                    "name" => query.OrderBy(s => s.Name.ToLower()),
                    "name_desc" => query.OrderByDescending(s => s.Name.ToLower()),
                    "location" => query.OrderBy(s => s.Location.ToLower()),
                    "location_desc" => query.OrderByDescending(s => s.Location.ToLower()),
                    "gender" => query.OrderBy(s => s.Gender),
                    "gender_desc" => query.OrderByDescending(s => s.Gender),
                    _ => query.OrderByDescending(s => s.Id),
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }

        public async Task<IEnumerable<string>> GetLocationsAsync()
        {
            return await _context.Singers.Select(s => s.Location)
                .Distinct().ToListAsync();
        }

        public async Task UpdateNoPhotoAsync(Singer singer)
        {
            // query have tracked
            var singerFromDb = await _context.Singers.FirstOrDefaultAsync(x => x.Id == singer.Id);
            if (singerFromDb != null)
            {
                singerFromDb.Name = singer.Name;
                singerFromDb.Location = singer.Location;
                singerFromDb.Introduction = singer.Introduction;
                singerFromDb.Gender = singer.Gender;
            }
        }
    }
}
