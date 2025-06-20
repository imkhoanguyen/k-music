using API.Controllers.Base;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Core.DTOs.Accounts;
using Music.Core.DTOs.Playlists;
using Music.Core.Utilities;
using Music.Core.Parameters;
using Music.Core.Service.Interfaces;

namespace API.Controllers.Customer
{
    [Authorize]
    public class PlaylistController : BaseApiController
    {
        private readonly IPlaylistService _playlistService;
        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedList<PlaylistDto>>> GetPlaylists([FromQuery] PlaylistParams prm)
        {
            var pagedList = await _playlistService.GetAllAsync(prm, p => p.IsPublic == true);
            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
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
