using System.Linq.Expressions;
using Music.Application.DTOs.Transactions;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;

namespace Music.Application.Service.Abstract
{
    public interface ITransactionService
    {
        public Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false);
        public Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression);
    }
}
