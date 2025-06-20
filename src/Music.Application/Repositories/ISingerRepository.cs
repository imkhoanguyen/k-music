using System.Linq.Expressions;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;

namespace Music.Application.Repositories
{
    public interface ISingerRepository : IRepository<Singer>
    {
        Task<PagedList<Singer>> GetAllAsync(SingerParams prm, Expression<Func<Singer,bool>>? expression = null, bool tracked = false);
        Task UpdateNoPhotoAsync(Singer singer);
        Task<IEnumerable<string>> GetLocationsAsync();
    }
}
