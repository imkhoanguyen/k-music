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
        public async Task<ActionResult> LikeSong([FromBody]AddLikeSongDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            await _accountService.LikeSongAsync(dto);
            return NoContent();
        }
    }
}
