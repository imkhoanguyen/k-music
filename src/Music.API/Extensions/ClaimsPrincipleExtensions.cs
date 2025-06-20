using Music.Core.Exceptions;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            var username = user.FindFirstValue(ClaimTypes.Name)
                ?? throw new BadRequestException("Cannot get username from token");

            return username;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new BadRequestException("Cannot get userId from token");

            return userId;
        }
    }
}
