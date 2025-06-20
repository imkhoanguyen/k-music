using System.Linq.Expressions;
using Music.Core.DTOs.Songs;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<PagedList<Song>> GetAllAsync(SongParams prm, Expression<Func<Song, bool>>? expression = null, bool tracked = false);
        Task UpdateSongAsync(Song song);
        Task UpdateSongFileAsync(Song song);
        Task UpdateImgFileAsync(Song song);
        Task UpdateSongVipAsync(int songId, bool vip);
        Task<IEnumerable<SongGenre>> GetAllGenreBySongIdAsync(int songId);
        Task<IEnumerable<SongSinger>> GetAllSingerBySongIdAsync(int songId);
        Task<IEnumerable<Song>> GetRandomAsync(int size, RandomSongRequest request, bool tracked = false);
    }
}
