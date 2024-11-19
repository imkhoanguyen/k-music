using API.Service.Abstract;
using KM.Application.DTOs.Auth;
using KM.Domain.Entities;
using KM.Domain.Enum;
using KM.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName) ??
                await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
            {
                throw new UnauthorizedException("Không tìm thấy tài khoản nào trùng khớp");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedException("Password không đúng");

            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender.ToString(),
                ImgUrl = user.ImgUrl,
                Token = await _tokenService.CreateTokenAsync(user),
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await CheckEmailExistAsync(dto.Email))
            {
                throw new BadRequestException("Email đã tồn tại");
            }

            if(await CheckUserNameExistAsync(dto.UserName))
            {
                throw new BadRequestException("UserName đã tồn tại");
            }

            var userToAdd = new AppUser
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email,
                Gender = Enum.Parse<Gender>(dto.Gender, true)
            };

            var result = await _userManager.CreateAsync(userToAdd, dto.Password);
            if(!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Đăng ký tài khoản thành công");
        }


        #region
        private async Task<bool> CheckEmailExistAsync(string text)
        {
            return await _userManager.Users.AnyAsync(u => u.Email.ToLower() == text.ToLower());
        }

        private async Task<bool> CheckUserNameExistAsync(string text)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName.ToLower() == text.ToLower());
        }

        #endregion
    }
}
