using System.Linq.Expressions;
using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.Repositories
{
    public class UserVipSubscriptionRepository : Repository<UserVipSubscription>, IUserVipSubscriptionRepository
    {
        private readonly MusicContext _context;
        public UserVipSubscriptionRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<UserVipSubscription?> GetAsync(Expression<Func<UserVipSubscription, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.UserVipSubscriptions.AsQueryable() : _context.UserVipSubscriptions.AsNoTracking().AsQueryable();

            query = query.Include(uvs => uvs.AppUser).Include(uvs => uvs.VipPackage);

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
