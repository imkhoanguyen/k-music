
using KM.Application.DTOs.Statistics;

namespace KM.Application.Service.Abstract
{
    public interface IStatisticService
    {
        Task<IEnumerable<DailyRevenue>> StatisticRevenue(int year);
    }
}