using System.Linq.Expressions;
using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.Repositories
{
    public class VipPackageRepository : Repository<VipPackage>, IVipPackageRepository
    {
        private readonly MusicContext _context;
        public VipPackageRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VipPackage>> GetAllAsync(Expression<Func<VipPackage, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.VipPackages.AsQueryable() : _context.VipPackages.AsNoTracking().AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }
    }
}
