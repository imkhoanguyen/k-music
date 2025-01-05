using API.Controllers.Base;
using KM.Application.DTOs.Statistics;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    public class StatisticController : BaseAdminApiController
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("revenue/{year:int}")]
        public async Task<ActionResult<IEnumerable<DailyRevenue>>> RevenueInYear(int year)
        {
            var data = await _statisticService.StatisticRevenue(year);
            return Ok(data);
        }
    }
}
