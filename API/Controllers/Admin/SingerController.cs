using API.Controllers.Base;
using API.Extensions;
using KM.Application.Authorization;
using KM.Application.DTOs.Singers;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Authorize]
    public class SingerController : BaseAdminApiController
    {
        private readonly ISingerService _singerService;

        public SingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SingerDto>>> GetSingers([FromQuery] SingerParams prm)
        {
            var singers = await _singerService.GetAllAsync(prm);

            Response.AddPaginationHeader(singers);

            return Ok(singers);
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SingerDto>>> GetAllSinger()
        {
            var singers = await _singerService.GetAllAsync();
            return Ok(singers);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<SingerDetailDto>> GetSinger(int id, [FromQuery] SongParams prm)
        {
            var singer = await _singerService.GetSingerDetail(s => s.Id == id, prm);
            Response.AddPaginationHeader(singer.SongList);
            return Ok(singer);
        }

        [HttpPost]
        [Authorize(Policy = AppPermission.Singer_Create)]
        public async Task<ActionResult<SingerDto>> CreateSinger([FromForm] SingerCreateDto singerCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var singer = await _singerService.CreateSingerAsync(singerCreateDto);
            return CreatedAtAction(nameof(GetSinger), new { id = singer.Id }, singer);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = AppPermission.Singer_Edit)]
        public async Task<ActionResult<SingerDto>> UpdateSinger([FromRoute] int id, [FromForm] SingerUpdateDto singerUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var singer = await _singerService.UpdateSingerAsync(id, singerUpdateDto);
            return Ok(singer);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = AppPermission.Singer_Delete)]
        public async Task<ActionResult> DeleteSinger([FromRoute] int id)
        {
            await _singerService.DeleteAsync(s => s.Id == id);
            return NoContent();
        }

        [HttpGet("locations")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<string>>> GetLocations()
        {
            var locations = await _singerService.GetLocationsAsync();
            return Ok(locations);
        }
    }
}
