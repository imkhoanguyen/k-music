using System.Linq.Expressions;
using Music.Core.DTOs.Transactions;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Service.Interfaces
{
    public interface ITransactionService
    {
        public Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false);
        public Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression);
    }
}
