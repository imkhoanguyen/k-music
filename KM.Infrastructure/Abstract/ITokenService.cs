﻿using Google.Apis.Auth;
using KM.Application.DTOs.Auth;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KM.Infrastructure.Abstract
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
