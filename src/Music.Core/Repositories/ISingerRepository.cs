using System.Linq.Expressions;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Repositories
{
    public interface ISingerRepository : IRepository<Singer>
    {
        Task<PagedList<Singer>> GetAllAsync(SingerParams prm, Expression<Func<Singer,bool>>? expression = null, bool tracked = false);
        Task UpdateNoPhotoAsync(Singer singer);
        Task<IEnumerable<string>> GetLocationsAsync();
    }
}
