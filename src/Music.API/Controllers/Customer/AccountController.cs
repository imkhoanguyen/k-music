using API.Controllers.Base;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Core.DTOs.Accounts;
using Music.Core.DTOs.Songs;
using Music.Core.Parameters;
using Music.Core.Service.Interfaces;
using Music.Core.DTOs.Playlists;

namespace API.Controllers.Customer
{
    [Authorize]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IPlaylistService _playlistService;

        public AccountController(IAccountService accountService, IPlaylistService playlistService)
        {
            _accountService = accountService;
            _playlistService = playlistService;
        }

        [HttpPost("like-song")]
        public async Task<ActionResult> LikeSong([FromBody]LikeSongDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.LikeSongAsync(dto);
            return NoContent();
        }

        [HttpPost("unlike-song")]
        public async Task<ActionResult> UnLikeSong([FromBody] LikeSongDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.UnlikeSongAsync(dto);
            return NoContent();
        }

        [HttpPost("check-like-song")]
        public async Task<ActionResult<bool>> CheckLikeSong([FromBody] LikeSongDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var result = await _accountService.CheckLikeSongAsync(dto);
            return Ok(result);
        }

        [HttpPost("like-singer")]
        public async Task<ActionResult> LikeSinger([FromBody] LikeSingerDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.LikeSingerAsync(dto);
            return NoContent();
        }

        [HttpPost("unlike-singer")]
        public async Task<ActionResult> UnLikeSinger([FromBody] LikeSingerDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.UnlikeSingerAsync(dto);
            return NoContent();
        }

        [HttpPost("check-like-singer")]
        public async Task<ActionResult<bool>> CheckLikeSinger([FromBody] LikeSingerDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var result = await _accountService.CheckLikeSingerAsync(dto);
            return Ok(result);
        }

        [HttpPost("like-playlist")]
        public async Task<ActionResult> LikePlaylist([FromBody] LikePlaylistDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.LikePlaylistAsync(dto);
            return NoContent();
        }

        [HttpPost("unlike-playlist")]
        public async Task<ActionResult> UnLikePlaylist([FromBody] LikePlaylistDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.UnlikePlaylistAsync(dto);
            return NoContent();
        }

        [HttpPost("check-like-playlist")]
        public async Task<ActionResult<bool>> CheckLikePlaylist([FromBody] LikePlaylistDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var result = await _accountService.CheckLikePlaylistAsync(dto);
            return Ok(result);
        }

        [HttpGet("get-song-liked")]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSongLiked([FromQuery] SongParams prm)
        {
            string userId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _accountService.GetSongLiked(prm, userId);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }

        [HttpGet("get-singer-liked")]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSingerLiked([FromQuery] SingerParams prm)
        {
            string userId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _accountService.GetSingerLiked(prm, userId);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }

        [HttpGet("get-playlist-liked")]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetPlaylistLiked([FromQuery] PlaylistParams prm)
        {
            string userId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _accountService.GetPlaylistLiked(prm, userId);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }

        [HttpGet("get-my-playlist")]
        public async Task<IEnumerable<PlaylistDto>> GetMyPlaylist([FromQuery] PlaylistParams prm)
        {
            string userId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _playlistService.GetAllAsync(prm, p => p.UserId == userId);
            Response.AddPaginationHeader(pagedList);
            return pagedList;
        }

    }
}
