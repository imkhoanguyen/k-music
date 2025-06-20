using Music.Infrastructure.DataAccess;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class SongSingerRepository : Repository<SongSinger>, ISongSingerRepository
    {
        public SongSingerRepository(MusicContext context) : base(context)
        {
        }
    }
}
