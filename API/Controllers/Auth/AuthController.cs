using System.Text;
using API.Controllers.Base;
using KM.Application.DTOs.Auth;
using KM.Domain.Entities;
using KM.Domain.Enum;
using KM.Domain.Exceptions;
using KM.Infrastructure.Abstract;
using KM.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.Auth
{
    public class AuthController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly EmailConfig _emailConfig;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService, IEmailService emailService, IOptions<EmailConfig> emailConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _emailConfig = emailConfig.Value;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName) ??
                await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
            {
                throw new BadRequestException("Không tìm thấy tài khoản nào trùng khớp");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
                throw new BadRequestException("Password không đúng");

            (string accessToken, DateTime expiredDateAccessToken) = await _tokenService.CreateAccessTokenAsync(user);
            string refreshToken = await _tokenService.CreateRefreshTokenAsync(user);

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
            if (request.RefreshToken.IsNullOrEmpty())
            {
                throw new BadRequestException("Could not get refresh token");
            }

            return Ok(await _tokenService.ValidRefreshToken(request.RefreshToken));
        }

        [HttpPost("ExternalLogin")]
        public async Task<ActionResult<UserLoginResponse>> ExternalLogin([FromBody] ExternalAuthDto dto)
        {
            var payload = await _tokenService.VerifyGoogleToken(dto);
            if (payload == null)
                throw new BadRequestException("Invalid External Authentication.");

            var info = new UserLoginInfo(dto.Provider, payload.Subject, dto.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null) // check user nay da dang nhap = gg lan nao chua
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new AppUser
                    {
                        Email = payload.Email,
                        UserName = payload.Email,
                        FullName = payload.Name,
                        ImgUrl = payload.Picture,
                        Gender = Gender.Male,
                    };

                    await _userManager.CreateAsync(user);
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    //have account
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            if (user == null)
            {
                throw new BadRequestException("Invalid External Authentication.");
            }

            (string accessToken, DateTime expiredDateAccessToken) = await _tokenService.CreateAccessTokenAsync(user);
            string refreshToken = await _tokenService.CreateRefreshTokenAsync(user);

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

        [HttpGet("forget-password")]
        public async Task<IActionResult> ForgetPassword(CancellationToken cancellationToken, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new BadRequestException("Email không tồn tại");

            string host = _emailConfig.AppUrl;

            string tokenConfirm = await _userManager.GeneratePasswordResetTokenAsync(user);

            string decodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(tokenConfirm));

            string resetPasswordUrl = $"{host}/reset-password?email={email}&token={decodedToken}";


            string body = $"Để reset password của bạn vui lòng click link sau: <a href=\"{resetPasswordUrl}\">Bấm vào đây để đổi lại mật khẩu mới</a>";


            await _emailService.SendMailAsync(cancellationToken, new EmailRequest
            {
                To = user.Email,
                Subject = "Reset Your Password ",
                Content = body,
            });

            return Ok(new { message = "Vui lòng kiểm tra email" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null) throw new BadRequestException("Email không tồn tại");

            if (string.IsNullOrEmpty(resetPasswordDto.Token))
                throw new BadRequestException("Không có token");

            string decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPasswordDto.Token));

            var identityResult = await _userManager.ResetPasswordAsync(user, decodedToken, resetPasswordDto.Password);

            if (identityResult.Succeeded)
            {
                return Ok(new { message = "Reset password thành công" });
            }
            else
            {
                throw new BadRequestException(identityResult.Errors.ToList()[0].Description);
            }
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
