using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Accounts;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

    }
}
