﻿using KM.Application.DTOs.Playlists;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
{
    public interface IPlaylistService
    {
        Task<PagedList<PlaylistDto>> GetAllAsync(PlaylistParams prm, bool tracked = false);
        Task<PlaylistDto> CreateAsync(PlaylistCreateDto dto);
        Task<PlaylistDto> AddSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDto> UpdateAsync(int playlistId, PlaylistUpdateDto dto);
        Task DeleteAsync(Expression<Func<Playlist, bool>> expression);
        Task DeleteSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDto> GetAsync(Expression<Func<Playlist, bool>> expression, bool tracked = false);
    }
}
