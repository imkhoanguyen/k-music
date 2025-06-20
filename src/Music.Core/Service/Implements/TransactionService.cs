using System.Linq.Expressions;
using Music.Core.Exceptions;
using Music.Core.Entities;
using Music.Core.DTOs.Transactions;
using Music.Core.Utilities;
using Music.Core.Parameters;
using Music.Core.Repositories;
using Music.Core.Service.Interfaces;

namespace Music.Application.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unit;

        public TransactionService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<Transaction, bool>>? expression = null, bool tracked = false)
        {
            var pagedList = await _unit.UserVipSubscription.GetAllAsync(prm, expression, false);

            var transactionDtos = pagedList.Select(uvs => new TransactionDto
            {
                Id = uvs.Id,
                Name = uvs.Plan.Name,
                Description = uvs.Plan.Description,
                Price = uvs.Plan.PriceSell,
                DurationDay = uvs.Plan.DurationDay,
                UserName = uvs.AppUser.UserName,
                StartDate = uvs.StartDate,
                EndDate = uvs.EndDate,
            });

            return new PagedList<TransactionDto>(transactionDtos, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
        }

        public async Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression)
        {
            var entity = await _unit.UserVipSubscription.GetAsync(expression);
            return entity ?? throw new NotFoundException("Không tìm thấy đơn hàng");
        }
    }
}
