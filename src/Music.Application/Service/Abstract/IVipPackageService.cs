using System.Linq.Expressions;
using KM.Application.DTOs.VipPackages;
using KM.Domain.Entities;

namespace KM.Application.Service.Abstract
{
    public interface IVipPackageService
    {
        Task<IEnumerable<VipPackage>> GetAllAsync(Expression<Func<VipPackage, bool>>? expression = null);
        Task<VipPackage> GetAsync(Expression<Func<VipPackage, bool>> expression);
        Task<VipPackage> CreateAsync(VipPackageCreateDto dto);
        Task<VipPackage> UpdateAsync(int vipPackageId, VipPackage entity);
        Task DeleteAsync(Expression<Func<VipPackage, bool>> expression);
    }
}
