﻿using KM.Application.DTOs.Accounts;
using KM.Application.DTOs.Playlists;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
{
    public interface IPlaylistService
    {
        Task<PagedList<PlaylistDto>> GetAllAsync(PlaylistParams prm, Expression<Func<Playlist, bool>>? expression = null);
        Task<PlaylistDto> CreateAsync(PlaylistCreateDto dto);
        Task<PlaylistDetailDto> AddSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDto> UpdateAsync(int playlistId, PlaylistUpdateDto dto);
        Task DeleteAsync(Expression<Func<Playlist, bool>> expression);
        Task DeleteSongAsync(int playlistId, List<int> songIdList);
        Task<PlaylistDetailDto> GetAsync(Expression<Func<Playlist, bool>> expression);
        Task<PlaylistDto> CreateAutoAsync(PlaylistCreateAutoDto dto);
        Task<PagedList<QuickViewPlaylistResponse>> GetQuickViewMyPlaylistAsync(PlaylistParams prm, QuickViewPlaylistRequest request);
        Task<bool> AddOrRemoveSong(QuickAddSongToPlaylistRequest request); // false = delete, true = add
        Task<PlaylistDetailDto1> GetAsync(Expression<Func<Playlist, bool>> expression, string userId);
    }
}
