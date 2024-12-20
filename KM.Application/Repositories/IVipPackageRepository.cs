﻿using System.Linq.Expressions;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface IVipPackageRepository : IRepository<VipPackage>
    {
        Task<IEnumerable<VipPackage>> GetAllAsync(Expression<Func<VipPackage, bool>>? expression = null, bool tracked = false);
    }
}
