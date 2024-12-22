using System.Linq.Expressions;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface IUserVipSubscriptionRepository : IRepository<UserVipSubscription>
    {
        public Task<IEnumerable<UserVipSubscription>> GetAllAsync(Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false);
        public Task<PagedList<UserVipSubscription>> GetAllAsync(TransactionParams prm, Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false);
    }
}
