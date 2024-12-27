using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Accounts;
using KM.Application.DTOs.Playlists;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    public class PlaylistController : BaseApiController
    {
        private readonly IPlaylistService _playlistService;
        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlaylistDetailDto1>> GetPlaylist(int id)
        {
            var userId = ClaimsPrincipleExtensions.GetUserId(User);
            return await _playlistService.GetAsync(p => p.Id == id, userId);
        }

        [HttpGet("get-quickview-playlist")]
        public async Task<ActionResult<IEnumerable<QuickViewPlaylistResponse>>> GetQuickViewPlaylist([FromQuery]PlaylistParams prm, [FromQuery] QuickViewPlaylistRequest request)
        {
            request.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _playlistService.GetQuickViewMyPlaylistAsync(prm, request);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }

        [HttpPost("add-or-delete-song")]
        public async Task<ActionResult<bool>> AddOrDeleteSong([FromBody]QuickAddSongToPlaylistRequest request)
        {
            request.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var result = await _playlistService.AddOrRemoveSong(request);
            return Ok(result);
        }

    }
}
