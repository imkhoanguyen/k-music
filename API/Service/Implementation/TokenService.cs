using API.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Service.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _jwtKey;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            _config = config;
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSetting:Key"]));
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(AppUser user)
        {
            var role = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role[0])
            };

            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(int.Parse(_config["JWTSetting:ExpiresInDays"])),
                SigningCredentials = creadentials,
                Issuer = _config["JWTSetting:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(jwt);
        }
    }
}
