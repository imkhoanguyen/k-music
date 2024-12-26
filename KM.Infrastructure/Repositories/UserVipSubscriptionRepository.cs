using System.Linq;
using System.Linq.Expressions;
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
    public class UserVipSubscriptionRepository : Repository<UserVipSubscription>, IUserVipSubscriptionRepository
    {
        private readonly MusicContext _context;
        public UserVipSubscriptionRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<UserVipSubscription>> GetAllAsync(Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.UserVipSubscriptions.AsQueryable() : _context.UserVipSubscriptions.AsNoTracking().AsQueryable();
            query = query.Include(uvs => uvs.AppUser).Include(uvs => uvs.VipPackage);
            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        public async Task<PagedList<UserVipSubscription>> GetAllAsync(TransactionParams prm, Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.UserVipSubscriptions.AsQueryable() : _context.UserVipSubscriptions.AsNoTracking().AsQueryable();

            query = query.Include(uvs => uvs.AppUser)
                    .Include(uvs => uvs.VipPackage);

            if (expression != null)
                query = query.Where(expression);

            if (!prm.Search.IsNullOrEmpty()) // search with song name and singer name
            {
                query = query.Where(uvs => uvs.VipPackage.Name.ToLower().Contains(prm.Search.ToLower())
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
                    "name" => query.OrderBy(uvs => uvs.VipPackage.Name),
                    "name_desc" => query.OrderByDescending(uvs => uvs.VipPackage.Name),
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

        public override async Task<UserVipSubscription?> GetAsync(Expression<Func<UserVipSubscription, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.UserVipSubscriptions.AsQueryable() : _context.UserVipSubscriptions.AsNoTracking().AsQueryable();

            query = query.Include(uvs => uvs.AppUser).Include(uvs => uvs.VipPackage);

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
