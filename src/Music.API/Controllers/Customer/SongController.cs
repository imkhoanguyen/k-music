using API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Core.DTOs.Songs;
using Music.Core.Service.Interfaces;

namespace API.Controllers.Customer
{
    [Authorize]
    public class SongController : BaseApiController
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("random-list")]
        public async Task<IEnumerable<SongDto>> GetRamdomSong([FromQuery] RandomSongRequest request)
        {
            return await _songService.GetRandomSongAsync(20, request);
        }

    }
}
