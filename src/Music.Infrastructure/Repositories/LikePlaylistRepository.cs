using KM.Application.Repositories;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class LikePlaylistRepository : Repository<LikePlaylist>, ILikePlaylistRepository
    {
        public LikePlaylistRepository(MusicContext context) : base(context)
        {
        }
    }
}
