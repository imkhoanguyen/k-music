using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class SongGenreRepository : Repository<SongGenre>, ISongGenreRepository
    {
        public SongGenreRepository(MusicContext context) : base(context)
        {
           
        }
    }
}
