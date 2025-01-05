using KM.Application.DTOs.Statistics;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;

namespace KM.Application.Service.Implementation
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unit;

        public StatisticService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<DailyRevenue>> StatisticRevenue(int year)
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

    }
}
