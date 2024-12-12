using API.Extensions;
using KM.Application.DTOs.Playlists;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using KM.Application.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly IPlaylistService _playlistService;

        public ClientController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("get-all-playlist")]
        public async Task<ActionResult<IEnumerable<PlaylistDto>>> GetPlaylists([FromQuery]PlaylistParams prm)
        {
            var pagedList = await _playlistService.GetAllAsync(prm);
            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
        }
    }
}
