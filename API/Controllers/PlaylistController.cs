using API.Extensions;
using KM.Application.DTOs.Playlists;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using KM.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlaylistController : BaseApiController
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<PlaylistDto>>> GetPlaylists([FromQuery] PlaylistParams prm)
        {
            var pagedList = await _playlistService.GetAllAsync(prm);
            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlaylistDetailDto>> GetPlaylist(int id)
        {
            return await _playlistService.GetAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistDto>> CreatePlaylist([FromForm] PlaylistCreateDto dto)
        {
            dto.UserId = User.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playlistDto = await _playlistService.CreateAsync(dto);
            return Ok(playlistDto);
        }

        [HttpPost("add-auto")]
        public async Task<ActionResult<PlaylistDto>> CreatePlaylistAuto([FromForm] PlaylistCreateAutoDto dto)
        {
            dto.UserId = User.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playlistDto = await _playlistService.CreateAutoAsync(dto);
            return Ok(playlistDto);
        }

        [HttpPost("{playlistId:int}/add-song")]
        public async Task<ActionResult<PlaylistDetailDto>> AddSongToPlaylist([FromRoute] int playlistId, [FromBody] List<int> songIdList)
        {
            var playlistDetailDto = await _playlistService.AddSongAsync(playlistId, songIdList);
            return Ok(playlistDetailDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PlaylistDto>> UpdatePlaylist([FromRoute]int id, [FromForm] PlaylistUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playlistDto = await _playlistService.UpdateAsync(id, dto);
            playlistDto.UserName = User.GetUsername();
            return Ok(playlistDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePlaylist([FromRoute] int id)
        {
            await _playlistService.DeleteAsync(p => p.Id == id);
            return NoContent();
        }

        [HttpDelete("{playlistId:int}/delete-song")]
        public async Task<ActionResult> DeleteSongInPlaylist([FromRoute] int playlistId, List<int> songIdList)
        {
            await _playlistService.DeleteSongAsync(playlistId, songIdList);
            return NoContent();
        }
    }
}
