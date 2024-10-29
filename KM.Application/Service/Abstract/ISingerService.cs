using KM.Application.DTOs.Singers;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
{
    public interface ISingerService
    {
        Task<PagedList<SingerDto>> GetAllAsync(SingerParams prm, bool tracked = false);
        Task<IEnumerable<SingerDto>> GetAllAsync(bool tracked = false);
        Task<SingerDto> GetAsync(Expression<Func<Singer, bool>> expression, bool tracked = false);
        Task<SingerDto> CreateSingerAsync(SingerCreateDto singerCreateDto);
        Task<SingerDto> UpdateSingerAsync(int id, SingerUpdateDto singerUpdateDto);
        Task DeleteAsync(Expression<Func<Singer, bool>> expression);
        Task<IEnumerable<string>> GetLocationsAsync();
    }
}
