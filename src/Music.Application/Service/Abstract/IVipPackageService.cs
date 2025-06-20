using System.Linq.Expressions;
using Music.Application.DTOs.VipPackages;
using Music.Domain.Entities;

namespace Music.Application.Service.Abstract
{
    public interface IVipPackageService
    {
        Task<IEnumerable<Plan>> GetAllAsync(Expression<Func<Plan, bool>>? expression = null);
        Task<Plan> GetAsync(Expression<Func<Plan, bool>> expression);
        Task<Plan> CreateAsync(VipPackageCreateDto dto);
        Task<Plan> UpdateAsync(int vipPackageId, Plan entity);
        Task DeleteAsync(Expression<Func<Plan, bool>> expression);
    }
}
