using System.Linq.Expressions;
using Music.Core.DTOs.VipPackages;
using Music.Core.Entities;

namespace Music.Core.Service.Interfaces
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
