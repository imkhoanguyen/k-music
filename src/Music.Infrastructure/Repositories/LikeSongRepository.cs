using Music.Infrastructure.DataAccess;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class LikeSongRepository : Repository<LikeSong>, ILikeSongRepository
    {
        public LikeSongRepository(MusicContext context) : base(context)
        {
        }
    }
}
