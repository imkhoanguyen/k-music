using System.Linq.Expressions;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;

namespace Music.Application.Repositories
{
    public interface IUserVipSubscriptionRepository : IRepository<Transaction>
    {
        public Task<PagedList<Transaction>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false);
    }
}
