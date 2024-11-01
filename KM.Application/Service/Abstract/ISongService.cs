﻿using KM.Application.DTOs.Songs;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
{
    public interface ISongService
    {
        Task<PagedList<SongDto>> GetAllAsync(SongParams prm, bool tracked = false);
        Task<SongDto> GetAsync(Expression<Func<Song, bool>> expression, bool tracked = false);
        Task<SongDto> CreateAsync(SongCreateDto songCreateDto);
        Task<SongDto> UpdateAsync(int songId, SongUpdateDto songUpdateDto);
        Task DeleteAsync(Expression<Func<Song, bool>> expression);
        Task UpdateVipAsync(int songId, bool vip);
    }
}
