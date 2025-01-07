using API.Controllers.Base;
using API.Extensions;
using KM.Application.Abstract;
using KM.Application.Authorization;
using KM.Application.DTOs.Songs;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Authorize]
    public class SongController : BaseAdminApiController
    {
        private readonly ISongService _songService;
        private readonly ICloudinaryService _cloudinaryService;

        public SongController(ISongService songService, ICloudinaryService cloudinaryService)
        {
            _songService = songService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSongs([FromQuery] SongParams prm)
        {
            var song = await _songService.GetAllAsync(prm);

            Response.AddPaginationHeader(song);

            return Ok(song);

        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<SongDto>> GetSong(int id)
        {
            var song = await _songService.GetAsync(s => s.Id == id);
            return Ok(song);

        }

        [HttpPost]
        [Authorize(Policy = AppPermission.Song_Create)]
        public async Task<ActionResult<SongDto>> CreateSong([FromForm] SongCreateDto songCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _songService.CreateAsync(songCreateDto);
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }

        [HttpPut("{songId:int}")]
        [Authorize(Policy = AppPermission.Song_Edit)]
        public async Task<ActionResult<SongDto>> UpdateSong([FromRoute] int songId, [FromForm] SongUpdateDto songUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _songService.UpdateAsync(songId, songUpdateDto);
            return Ok(song);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = AppPermission.Song_Delete)]
        public async Task<ActionResult> DeleteSong([FromRoute] int id)
        {
            await _songService.DeleteAsync(s => s.Id == id);
            return NoContent();
        }

        [HttpPut("update-vip/{songId:int}")]
        [Authorize(Policy = AppPermission.Song_Delete)]
        public async Task<ActionResult> UpdateSongVip([FromRoute] int songId, [FromBody] bool vip)
        {
            await _songService.UpdateVipAsync(songId, vip);

            return NoContent();
        }

    }
}
