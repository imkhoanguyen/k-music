using System.Linq.Expressions;
using KM.Application.DTOs.Playlists;
using KM.Application.DTOs.Transactions;
using KM.Application.Mappers;
using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Domain.Exceptions;

namespace KM.Application.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unit;

        public TransactionService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<PagedList<TransactionDto>> GetAllAsync(TransactionParams prm, Expression<Func<UserVipSubscription, bool>>? expression = null, bool tracked = false)
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

        public async Task<UserVipSubscription> GetAsync(Expression<Func<UserVipSubscription, bool>> expression)
        {
            var entity = await _unit.UserVipSubscription.GetAsync(expression);
            return entity ?? throw new NotFoundException("Không tìm thấy đơn hàng");
        }
    }
}
