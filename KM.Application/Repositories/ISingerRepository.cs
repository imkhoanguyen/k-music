using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface ISingerRepository : IRepository<Singer>
    {
        Task<PagedList<Singer>> GetAllAsync(SingerParams prm, bool tracked = false);
        Task UpdateNoPhotoAsync(Singer singer);
        Task<IEnumerable<string>> GetLocationsAsync();
        Task<IEnumerable<Singer>> GetAllWithoutPagingAsync(bool tracked = false);
    }
}
