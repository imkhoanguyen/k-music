using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Singers;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    [Authorize]
    public class SingerController : BaseApiController
    {
        private readonly ISingerService _singerService;

        public SingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SingerDetailDto1>> GetSinger(int id, [FromQuery] SongParams prm)
        {
            var userId = ClaimsPrincipleExtensions.GetUserId(User);
            var singer = await _singerService.GetSingerDetail(s => s.Id == id, prm, userId);
            Response.AddPaginationHeader(singer.SongList);
            return Ok(singer);
        }
    }
}
