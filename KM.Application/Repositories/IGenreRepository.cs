using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;


namespace KM.Application.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllAsync(bool tracked = false);
        Task<PagedList<Genre>> GetAllAsync(GenreParams baseParams, bool tracked = false);
    }
}
