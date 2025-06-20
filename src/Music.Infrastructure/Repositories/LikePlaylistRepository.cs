using Music.Infrastructure.DataAccess;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class LikePlaylistRepository : Repository<LikePlaylist>, ILikePlaylistRepository
    {
        public LikePlaylistRepository(MusicContext context) : base(context)
        {
        }
    }
}
