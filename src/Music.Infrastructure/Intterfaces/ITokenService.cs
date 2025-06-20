using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Music.Core.DTOs.Auth;
using Music.Core.Entities;

namespace Music.Infrastructure.Intterfaces
{
    public interface ITokenService
    {
        public Task<(string, DateTime)> CreateAccessTokenAsync(AppUser user);
        public Task<string> CreateRefreshTokenAsync(AppUser user);
        public Task<UserLoginResponse> ValidRefreshToken(string rfToken);
        public Task ValidToken(TokenValidatedContext context);
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth);
    }
}
