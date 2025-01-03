using API.Controllers.Base;
using KM.Application.DTOs.Auth;
using KM.Application.Interfaces;
using KM.Domain.Entities;
using KM.Domain.Enum;
using KM.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.Auth
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
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] LoginDto dto)
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

            (string accessToken, DateTime expiredDateAccessToken) = await _tokenService.CreateAccessTokenAsync(user);
            string refreshToken= await _tokenService.CreateRefreshTokenAsync(user);

            return Ok(new UserLoginResponse
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Gender = user.Gender.ToString(),
                ImgUrl = user.ImgUrl,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiredDateAccessToken = expiredDateAccessToken,
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await CheckEmailExistAsync(dto.Email))
            {
                throw new BadRequestException("Email đã tồn tại");
            }

            if (await CheckUserNameExistAsync(dto.UserName))
            {
                throw new BadRequestException("UserName đã tồn tại");
            }

            var userToAdd = new AppUser
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email,
                Gender = Enum.Parse<Gender>(dto.Gender, true),
                ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1735543269/user_pez7rf.webp"
            };

            var result = await _userManager.CreateAsync(userToAdd, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var resultAddRole = await _userManager.AddToRoleAsync(userToAdd, "Customer");
            if (!resultAddRole.Succeeded)
            {
                var deleteResult = await _userManager.DeleteAsync(userToAdd);
                if (!deleteResult.Succeeded)
                {
                    throw new BadRequestException("Failed to rollback user creation. Please contact support.");
                }

                throw new BadRequestException("Thêm quyền thất bại. Người dùng đã bị xóa.");
            }

            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<UserLoginResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if(request.RefreshToken.IsNullOrEmpty())
            {
                throw new BadRequestException("Could not get refresh token");
            }

            return Ok(await _tokenService.ValidRefreshToken(request.RefreshToken));
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
