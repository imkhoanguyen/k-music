using System.Linq.Expressions;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface IUserVipSubscriptionRepository : IRepository<UserVipSubscription>
    {
        public Task<IEnumerable<UserVipSubscription>> GetAllAsync(Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false);
    }
}
