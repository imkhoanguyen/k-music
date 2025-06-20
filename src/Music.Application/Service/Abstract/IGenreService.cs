using Music.Application.DTOs.Genres;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Service.Abstract
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
