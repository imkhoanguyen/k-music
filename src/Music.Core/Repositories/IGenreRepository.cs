using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<PagedList<Genre>> GetAllAsync(GenreParams baseParams, bool tracked = false);
    }
}
