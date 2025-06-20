using System.Linq.Expressions;
using Music.Application.DTOs.Songs;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;

namespace Music.Application.Repositories
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
