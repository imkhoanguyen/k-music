using System.Linq;
using System.Linq.Expressions;
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
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly MusicContext _context;
        public TransactionRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Transaction>> GetAllAsync(Expression<Func<Transaction, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Transactions.AsQueryable() : _context.Transactions.AsNoTracking().AsQueryable();
            query = query.Include(uvs => uvs.AppUser).Include(uvs => uvs.Plan);
            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        public async Task<PagedList<Transaction>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Transactions.AsQueryable() : _context.Transactions.AsNoTracking().AsQueryable();

            query = query.Include(uvs => uvs.AppUser)
                    .Include(uvs => uvs.Plan);

            if (expression != null)
                query = query.Where(expression);

            if (!prm.Search.IsNullOrEmpty()) // search with song name and singer name
            {
                query = query.Where(uvs => uvs.Plan.Name.ToLower().Contains(prm.Search.ToLower())
                || uvs.AppUser.UserName.ToLower().Contains(prm.Search.ToLower())
                || uvs.AppUser.FullName.ToLower().Contains(prm.Search.ToLower())
                || uvs.Price.ToString().Contains(prm.Search.ToLower()));
            }

            if (prm.StartDate.HasValue && prm.EndDate.HasValue)
            {
                query = query.Where(uvs => uvs.StartDate >= prm.StartDate && uvs.StartDate <= prm.EndDate);
            }

            if (!prm.OrderBy.IsNullOrEmpty())
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(uvs => uvs.Id),
                    "id_desc" => query.OrderByDescending(uvs => uvs.Id),
                    "name" => query.OrderBy(uvs => uvs.Plan.Name),
                    "name_desc" => query.OrderByDescending(uvs => uvs.Plan.Name),
                    "startDate" => query.OrderBy(uvs => uvs.EndDate),
                    "startDate_desc" => query.OrderByDescending(uvs => uvs.EndDate),
                    "endDate" => query.OrderBy(uvs => uvs.EndDate),
                    "endDate_desc" => query.OrderByDescending(uvs => uvs.EndDate),
                    "price" => query.OrderBy(uvs => uvs.Price),
                    "price_desc" => query.OrderByDescending(uvs => uvs.Price),
                    _ => query.OrderByDescending(uvs => uvs.Id)
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }

        public override async Task<Transaction?> GetAsync(Expression<Func<Transaction, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.Transactions.AsQueryable() : _context.Transactions.AsNoTracking().AsQueryable();

            query = query.Include(uvs => uvs.AppUser).Include(uvs => uvs.Plan);

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
