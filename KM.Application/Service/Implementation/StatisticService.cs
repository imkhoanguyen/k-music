using KM.Application.DTOs.Statistics;
using KM.Application.Mappers;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace KM.Application.Service.Implementation
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<AppUser> _userManager;

        public StatisticService(IUnitOfWork unit, UserManager<AppUser> userManager)
        {
            _unit = unit;
            _userManager = userManager;
        }

        public async Task<IEnumerable<DailyRevenue>> StatisticRevenueAsync(int year)
        {
            var uvsList = await _unit.UserVipSubscription.GetAllAsync(uvs => uvs.StartDate.Year == year);

            var dailyRevenueList = uvsList
                .GroupBy(uvs => uvs.StartDate.Date)
                .Select(group => new DailyRevenue
                {
                    Date = group.Key,
                    TotalRevenue = group.Sum(uvs => uvs.Price)
                })
                .ToList();

            return dailyRevenueList;
        }

        public int GetTotalUser()
        {
            var total = _userManager.Users.ToList().Count();
            return total;
        }

        public async Task<int> GetTotalSongAsync()
        {
            var songs = await _unit.Song.GetAllAsync();
            return songs.Count();
        }

        public async Task<int> GetTotalPlaylistAsync()
        {
            var playlists = await _unit.Playlist.GetAllAsync();
            return playlists.Count();
        }

        public async Task<decimal> GetTotalPriceInDayAsync()
        {
            var today = DateTime.Today;
            var uvsList = await _unit.UserVipSubscription.GetAllAsync(uvs => uvs.StartDate.Date == today);

            decimal totalPrice = uvsList.Sum(uvs => uvs.Price);

            return totalPrice;
        }

        public async Task<TopFavorite> GetTopFavoriteAsync(int top)
        {
            var likeSinger = await _unit.LikeSinger.GetAllAsync();
            var topLikeSinger = likeSinger
                .GroupBy(ls => ls.SingerId)
                .OrderByDescending(group => group.Count()) // Sắp xếp theo số lượng thích giảm dần
                .Take(top)
                .Select(group => group.Key)
                .ToList();
            var topSingers = await _unit.Singer.GetAllAsync(s => topLikeSinger.Contains(s.Id));

            var likeSong = await _unit.LikeSong.GetAllAsync();
            var topLikeSong = likeSong
                .GroupBy(ls => ls.SongId)
                .OrderByDescending(group => group.Count())
                .Take(top)
                .Select(group => group.Key)
                .ToList();
            var topSongs = await _unit.Song.GetAllAsync(s => topLikeSong.Contains(s.Id));

            var likePlaylist = await _unit.LikePlaylist.GetAllAsync();
            var topLikePlaylist = likePlaylist
                .GroupBy(ls => ls.PlaylistId)
                .OrderByDescending(group => group.Count())
                .Take(top)
                .Select (group => group.Key)
                .ToList();
            var topPlaylists = await _unit.Playlist.GetAllAsync(p =>topLikePlaylist.Contains(p.Id));

            return new TopFavorite
            {
                PlaylistList = topPlaylists.Select(PlaylistMapper.EntityToPlaylistDto),
                SongList = topSongs.Select(SongMapper.EntityToSongDto),
                SingerList = topSingers.Select(SingerMapper.EntityToSingerDto)
            };
           
        }

    }
}
