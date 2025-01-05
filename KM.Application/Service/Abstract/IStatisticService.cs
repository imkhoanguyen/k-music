
using KM.Application.DTOs.Statistics;

namespace KM.Application.Service.Abstract
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