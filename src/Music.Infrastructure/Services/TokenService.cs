using Google.Apis.Auth;
using Music.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Music.Core.DTOs.Auth;
using Music.Core.Entities;
using Music.Core.Utilities;
using Music.Core.Repositories;
using Music.Infrastructure.Intterfaces;
using Music.Core.Exceptions;

namespace Music.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfig _tokenConfig;
        private readonly SymmetricSecurityKey _jwtKey;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IUnitOfWork _unit;
        private readonly GoogleAuthConfig _googleAuthConfig;

        public TokenService(IOptions<TokenConfig> tokenConfig, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, IUnitOfWork unit, IOptions<GoogleAuthConfig> ggAuthConfig)
        {
            _tokenConfig = tokenConfig.Value;
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.Key));
            _userManager = userManager;
            _roleManager = roleManager;
            _unit = unit;
            _googleAuthConfig = ggAuthConfig.Value;
        }

        public async Task<(string, DateTime)> CreateAccessTokenAsync(AppUser user)
        {
            DateTime expiredToken = DateTime.Now.AddMinutes(_tokenConfig.AccessTokenExpiredByMinutes);

            var role = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role[0])
            };

            // Thêm các claims dựa trên role
            var roleClaims = await _roleManager.GetClaimsAsync(await _roleManager.FindByNameAsync(role[0]));
            userClaims.AddRange(roleClaims);

            // thêm vip subcription vào ko có là null
            var allSubcription = await _unit.UserVipSubscription.GetAllAsync(uvs => uvs.UserId == user.Id);
            if (allSubcription.Any())
            {
                // get những gói vip chưa hết hạn
                var activeSubscriptions = allSubcription.Where(uvs => uvs.EndDate >= DateTime.Now).ToList();
                if (activeSubscriptions.Any())
                {
                    var date = activeSubscriptions.Max(uvs => uvs.EndDate);
                    var subcriptionClaim = new Claim("VipExpiredDate", date.ToString("o"));
                    userClaims.Add(subcriptionClaim);
                }
            }



            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expiredToken,
                SigningCredentials = creadentials,
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(jwt);

            await _userManager.SetAuthenticationTokenAsync(user, SD.AccessTokenProvider, SD.AccessToken, accessToken);

            return (accessToken, expiredToken);
        }

        public async Task ValidToken(TokenValidatedContext context)
        {
            var claims = context.Principal.Claims.ToList();
            if (claims.Count == 0)
            {
                context.Fail("This token contains no information");
                return;
            }

            var identity = context.Principal.Identity as ClaimsIdentity;


            string userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    context.Fail("This token invalid for user");
                    return;
                }
            }
        }

        public async Task<string> CreateRefreshTokenAsync(AppUser user)
        {
            DateTime expiredRefreshToken = DateTime.Now.AddHours(_tokenConfig.RefreshTokenExpiredByHours);
            var role = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role[0])
            };

            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expiredRefreshToken,
                SigningCredentials = creadentials,
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = tokenHandler.WriteToken(jwt);

            await _userManager.SetAuthenticationTokenAsync(user, SD.RefreshTokenProvider, SD.RefreshToken, refreshToken);


            return refreshToken;
        }

        public async Task<UserLoginResponse> ValidRefreshToken(string rfToken)
        {
            var claimPrinciple = new JwtSecurityTokenHandler().ValidateToken(
                rfToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.Key)),
                        ValidIssuer = _tokenConfig.Issuer,
                        ValidateIssuer = true,
                        ValidAudience = _tokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = false, // ko valid thời gian của refresh (vì ko làm chức năng buộc user logout)
                        ClockSkew = TimeSpan.Zero,
                    },
                     out _
                );

            if (claimPrinciple == null)
            {
                throw new BadRequestException("RefreshToken Invalid");
            }

            string userId = claimPrinciple?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            var token = await _userManager.GetAuthenticationTokenAsync(user, SD.AccessTokenProvider, SD.AccessToken);

            if (!string.IsNullOrEmpty(token))
            {
                (string accessToken, DateTime expiredDateAccessToken) = await CreateAccessTokenAsync(user);
                string refreshToken = await CreateRefreshTokenAsync(user);

                return new UserLoginResponse
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Gender = user.Gender.ToString(),
                    ImgUrl = user.ImgUrl,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiredDateAccessToken = expiredDateAccessToken,
                };
            }

            throw new BadRequestException("Problem when check valid refresh token");
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleAuthConfig.ClientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }
    }
}
