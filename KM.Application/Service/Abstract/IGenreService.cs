using KM.Application.DTOs.Genres;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
{
    public interface IGenreService
    {
        Task<PagedList<GenreDto>> GetAllAsync(GenreParams prm, bool tracked);
        Task<IEnumerable<GenreDto>> GetAllAsync(bool tracked);
        Task<GenreDto?> GetAsync(Expression<Func<Genre, bool>> expression);
        Task<GenreDto> CreateAsync(GenreCreateDto dto);
        Task<GenreDto> UpdateAsync(int id, GenreDto dto);
        Task DeleteAsync(Expression<Func<Genre, bool>> expression);
    }
}
