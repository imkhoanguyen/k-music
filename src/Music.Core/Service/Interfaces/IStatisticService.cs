using Music.Core.DTOs.Statistics;

namespace Music.Core.Service.Interfaces
{
    public interface IStatisticService
    {
        Task<TopFavorite> GetTopFavoriteAsync(int top);
        Task<int> GetTotalPlaylistAsync();
        Task<decimal> GetTotalPriceInDayAsync();
        Task<int> GetTotalSongAsync();
        int GetTotalUser();
        Task<IEnumerable<DailyRevenue>> StatisticRevenueAsync(int year);
    }
}