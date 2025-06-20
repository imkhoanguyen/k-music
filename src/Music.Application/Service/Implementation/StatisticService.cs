using Music.Application.DTOs.Statistics;
using Music.Application.Mappers;
using Music.Application.Repositories;
using Music.Application.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Music.Domain.Entities;

namespace Music.Application.Service.Implementation
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
            // Get top liked singers with counts
            var likeSinger = await _unit.LikeSinger.GetAllAsync();
            var topLikeSinger = likeSinger
                .GroupBy(ls => ls.SingerId)
                .Select(group => new { SingerId = group.Key, Count = group.Count() })
                .OrderByDescending(group => group.Count)
                .Take(top)
                .ToList();

            var topSingers = (await _unit.Singer.GetAllAsync(s => topLikeSinger.Select(ls => ls.SingerId).Contains(s.Id)))
                .Select(singer => new { Entity = singer, Count = topLikeSinger.First(ls => ls.SingerId == singer.Id).Count })
                .OrderByDescending(item => item.Count)
                .ToList();

            // Get top liked songs with counts
            var likeSong = await _unit.LikeSong.GetAllAsync();
            var topLikeSong = likeSong
                .GroupBy(ls => ls.SongId)
                .Select(group => new { SongId = group.Key, Count = group.Count() })
                .OrderByDescending(group => group.Count)
                .Take(top)
                .ToList();

            var topSongs = (await _unit.Song.GetAllAsync(s => topLikeSong.Select(ls => ls.SongId).Contains(s.Id)))
                .Select(song => new { Entity = song, Count = topLikeSong.First(ls => ls.SongId == song.Id).Count })
                .OrderByDescending(item => item.Count)
                .ToList();

            // Get top liked playlists with counts
            var likePlaylist = await _unit.LikePlaylist.GetAllAsync();
            var topLikePlaylist = likePlaylist
                .GroupBy(ls => ls.PlaylistId)
                .Select(group => new { PlaylistId = group.Key, Count = group.Count() })
                .OrderByDescending(group => group.Count)
                .Take(top)
                .ToList();

            var topPlaylists = (await _unit.Playlist.GetAllAsync(p => topLikePlaylist.Select(lp => lp.PlaylistId).Contains(p.Id)))
                .Select(playlist => new { Entity = playlist, Count = topLikePlaylist.First(lp => lp.PlaylistId == playlist.Id).Count })
                .OrderByDescending(item => item.Count)
                .ToList();

            return new TopFavorite
            {
                PlaylistList = topPlaylists.Select(item => PlaylistMapper.EntityToPlaylistDto(item.Entity)),
                SongList = topSongs.Select(item => SongMapper.EntityToSongDto(item.Entity)),
                SingerList = topSingers.Select(item => SingerMapper.EntityToSingerDto(item.Entity))
            };
        }

    }
}
