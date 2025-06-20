using System.Linq.Expressions;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public Task<PagedList<Transaction>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false);
    }
}
