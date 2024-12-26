using System.Linq.Expressions;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface ISingerRepository : IRepository<Singer>
    {
        Task<PagedList<Singer>> GetAllAsync(SingerParams prm, Expression<Func<Singer,bool>>? expression = null, bool tracked = false);
        Task UpdateNoPhotoAsync(Singer singer);
        Task<IEnumerable<string>> GetLocationsAsync();
    }
}
