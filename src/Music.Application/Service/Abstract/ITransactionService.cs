using System.Linq.Expressions;
using KM.Application.DTOs.Transactions;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Service.Abstract
{
    public interface ITransactionService
    {
        public Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false);
        public Task<UserVipSubscription> GetAsync(Expression<Func<UserVipSubscription, bool>> expression);
    }
}
