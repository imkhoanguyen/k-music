using System.Linq.Expressions;
using Music.Application.DTOs.Playlists;
using Music.Application.DTOs.Transactions;
using Music.Application.Mappers;
using Music.Application.Parameters;
using Music.Application.Repositories;
using Music.Application.Service.Abstract;
using Music.Application.Utilities;
using Music.Domain.Exceptions;
using Music.Domain.Entities;

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
                Name = uvs.VipPackage.Name,
                Description = uvs.VipPackage.Description,
                Price = uvs.VipPackage.PriceSell,
                DurationDay = uvs.VipPackage.DurationDay,
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
