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

    }
}
