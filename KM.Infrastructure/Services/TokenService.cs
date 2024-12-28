﻿using KM.Application.DTOs.Auth;
using KM.Application.Interfaces;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Domain.Exceptions;
using KM.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KM.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfig _config;
        private readonly SymmetricSecurityKey _jwtKey;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public TokenService(IOptions<TokenConfig> config, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _config = new TokenConfig
            {
                Key = config.Value.Key,
                Audience = config.Value.Audience,
                Issuer = config.Value.Issuer,
                AccessTokenExpiredByMinutes = config.Value.AccessTokenExpiredByMinutes,
                RefreshTokenExpiredByHours = config.Value.RefreshTokenExpiredByHours,
            };
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<(string, DateTime)> CreateAccessTokenAsync(AppUser user)
        {
            DateTime expiredToken = DateTime.Now.AddSeconds(_config.AccessTokenExpiredByMinutes);

            var role = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, role[0])
            };

            // Thêm các claims dựa trên role
            var roleClaims = await _roleManager.GetClaimsAsync(await _roleManager.FindByNameAsync(role[0]));
            userClaims.AddRange(roleClaims);


            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expiredToken,
                SigningCredentials = creadentials,
                Issuer = _config.Issuer,
                Audience = _config.Audience,
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
            if(claims.Count == 0)
            {
                context.Fail("This token contains no information");
                return;
            }

            var identity = context.Principal.Identity as ClaimsIdentity;


            string userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);

                if(user == null)
                {
                    context.Fail("This token invalid for user");
                    return;
                }
            }
        }

        public async Task<string> CreateRefreshTokenAsync(AppUser user)
        {
            DateTime expiredRefreshToken = DateTime.Now.AddHours(_config.RefreshTokenExpiredByHours);
            var role = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, role[0])
            };

            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expiredRefreshToken,
                SigningCredentials = creadentials,
                Issuer = _config.Issuer,
                Audience = _config.Audience,
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key)),
                        ValidIssuer = _config.Issuer,
                        ValidateIssuer = true,
                        ValidAudience = _config.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = false, // ko valid thời gian của refresh (vì ko làm chức năng buộc user logout)
                        ClockSkew = TimeSpan.Zero,
                    },
                     out _
                );

            if(claimPrinciple == null)
            {
                throw new UnauthorizedException("RefreshToken Invalid");
            }

            string userId = claimPrinciple?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            var token = await _userManager.GetAuthenticationTokenAsync(user, SD.AccessTokenProvider, SD.AccessToken);

            if(!string.IsNullOrEmpty(token))
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

            throw new UnauthorizedException("Problem when check valid refresh token");
        }
    }
}
