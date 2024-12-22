using System.Linq.Expressions;
using KM.Application.DTOs.Transactions;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Service.Abstract
{
    public interface ITransactionService
    {
        public Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<UserVipSubscription>>? expression = null, bool tracked = false);
    }
}
