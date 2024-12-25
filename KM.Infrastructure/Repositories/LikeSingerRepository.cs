using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class LikeSingerRepository : Repository<LikeSinger>, ILikeSingerRepository
    {
        public LikeSingerRepository(MusicContext context) : base(context)
        {
        }
    }
}
