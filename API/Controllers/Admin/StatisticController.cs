using API.Controllers.Base;
using KM.Application.Authorization;
using KM.Application.DTOs.Statistics;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Authorize(Policy = AppPermission.Access_Admin)]
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
            var data = await _statisticService.StatisticRevenueAsync(year);
            return Ok(data);
        }

        [HttpGet("overview")]
        public async Task<ActionResult<Overview>> Overview()
        {
            var overview = new Overview
            {
                TotalPlaylist = await _statisticService.GetTotalPlaylistAsync(),
                TotalPrice = await _statisticService.GetTotalPriceInDayAsync(),
                TotalSong = await _statisticService.GetTotalSongAsync(),
                TotalUser = _statisticService.GetTotalUser()
            };

            return Ok(overview);
        }

        [HttpGet("top-favorite/{top:int}")]
        public async Task<TopFavorite> TopFavorite(int top)
        {
            return await _statisticService.GetTopFavoriteAsync(top);
        }
    }
}
