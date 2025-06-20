using Music.Application.DTOs.Songs;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Service.Abstract
{
    public interface ISongService
    {
        Task<PagedList<SongDto>> GetAllAsync(SongParams prm, Expression<Func<Song, bool>>? expression = null);
        Task<SongDto> GetAsync(Expression<Func<Song, bool>> expression);
        Task<SongDto> CreateAsync(SongCreateDto songCreateDto);
        Task<SongDto> UpdateAsync(int songId, SongUpdateDto songUpdateDto);
        Task DeleteAsync(Expression<Func<Song, bool>> expression);
        Task UpdateVipAsync(int songId, bool vip);
        Task<IEnumerable<SongDto>> GetAllAsync(Expression<Func<Song, bool>>? expression = null);
        Task<IEnumerable<SongDto>> GetRandomSongAsync(int size, RandomSongRequest requset);
    }
}
