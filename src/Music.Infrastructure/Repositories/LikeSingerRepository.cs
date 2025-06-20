using Music.Infrastructure.DataAccess;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class LikeSingerRepository : Repository<LikeSinger>, ILikeSingerRepository
    {
        public LikeSingerRepository(MusicContext context) : base(context)
        {
        }
    }
}
