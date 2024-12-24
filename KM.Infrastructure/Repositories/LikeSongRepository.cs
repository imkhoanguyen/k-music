using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class LikeSongRepository : Repository<LikeSong>, ILikeSongRepository
    {
        public LikeSongRepository(MusicContext context) : base(context)
        {
        }
    }
}
