using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Singers;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    public class SingerController : BaseAdminApiController
    {
        private readonly ISingerService _singerService;

        public SingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SingerDto>>> GetSingers([FromQuery] SingerParams prm)
        {
            var singers = await _singerService.GetAllAsync(prm);

            Response.AddPaginationHeader(singers);

            return Ok(singers);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<SingerDto>>> GetAllSinger()
        {
            var singers = await _singerService.GetAllAsync();
            return Ok(singers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SingerDetailDto>> GetSinger(int id, [FromQuery] SongParams prm)
        {
            var singer = await _singerService.GetSingerDetail(s => s.Id == id, prm);
            Response.AddPaginationHeader(singer.SongList);
            return Ok(singer);
        }

        [HttpPost]
        public async Task<ActionResult<SingerDto>> CreateSinger([FromForm] SingerCreateDto singerCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var singer = await _singerService.CreateSingerAsync(singerCreateDto);
            return CreatedAtAction(nameof(GetSinger), new { id = singer.Id }, singer);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SingerDto>> UpdateSinger([FromRoute] int id, [FromForm] SingerUpdateDto singerUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var singer = await _singerService.UpdateSingerAsync(id, singerUpdateDto);
            return Ok(singer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSinger([FromRoute] int id)
        {
            await _singerService.DeleteAsync(s => s.Id == id);
            return NoContent();
        }

        [HttpGet("locations")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocations()
        {
            var locations = await _singerService.GetLocationsAsync();
            return Ok(locations);
        }
    }
}
