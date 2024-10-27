using KM.Domain.Entities;
using KM.Domain.Parameters;
using KM.Domain.Utilities;

namespace KM.Domain.Repositories
{
    public interface IGenreRepository : IRepository<Genre> 
    {
        Task<IEnumerable<Genre>> GetAllAsync(bool tracked = false);
        Task<PagedList<Genre>> GetAllAsync(GenreParams baseParams, bool tracked = false);
    }
}
