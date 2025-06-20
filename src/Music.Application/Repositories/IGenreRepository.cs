using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;


namespace Music.Application.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<PagedList<Genre>> GetAllAsync(GenreParams baseParams, bool tracked = false);
    }
}
