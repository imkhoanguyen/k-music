﻿using Music.Application.DTOs.Singers;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Service.Abstract
{
    public interface ISingerService
    {
        Task<PagedList<SingerDto>> GetAllAsync(SingerParams prm, Expression<Func<Singer, bool>>? expression = null);
        Task<IEnumerable<SingerDto>> GetAllAsync();
        Task<SingerDto> GetAsync(Expression<Func<Singer, bool>> expression);
        Task<SingerDto> CreateSingerAsync(SingerCreateDto singerCreateDto);
        Task<SingerDto> UpdateSingerAsync(int id, SingerUpdateDto singerUpdateDto);
        Task DeleteAsync(Expression<Func<Singer, bool>> expression);
        Task<IEnumerable<string>> GetLocationsAsync();
        Task<SingerDetailDto> GetSingerDetail(Expression<Func<Singer, bool>> expression, SongParams prm);
        Task<SingerDetailDto1> GetSingerDetail(Expression<Func<Singer, bool>> expression, SongParams prm, string userId);

    }
}
