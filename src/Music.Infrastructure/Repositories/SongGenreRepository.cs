using Music.Infrastructure.DataAccess;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class SongGenreRepository : Repository<SongGenre>, ISongGenreRepository
    {
        public SongGenreRepository(MusicContext context) : base(context)
        {
           
        }
    }
}
