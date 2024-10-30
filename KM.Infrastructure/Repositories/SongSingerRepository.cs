using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class SongSingerRepository : Repository<SongSinger>, ISongSingerRepository
    {
        public SongSingerRepository(MusicContext context) : base(context)
        {
        }
    }
}
