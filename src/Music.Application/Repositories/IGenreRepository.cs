using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;


namespace KM.Application.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<PagedList<Genre>> GetAllAsync(GenreParams baseParams, bool tracked = false);
    }
}
