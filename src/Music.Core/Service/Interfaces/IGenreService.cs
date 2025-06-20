using Music.Core.DTOs.Genres;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;
using System.Linq.Expressions;

namespace Music.Core.Service.Interfaces
{
    public interface IGenreService
    {
        Task<PagedList<GenreDto>> GetAllAsync(GenreParams prm, bool tracked);
        Task<IEnumerable<GenreDto>> GetAllAsync(Expression<Func<Genre, bool>>? expression = null);
        Task<GenreDto?> GetAsync(Expression<Func<Genre, bool>> expression);
        Task<GenreDto> CreateAsync(GenreCreateDto dto);
        Task<GenreDto> UpdateAsync(int id, GenreDto dto);
        Task DeleteAsync(Expression<Func<Genre, bool>> expression);
    }
}
