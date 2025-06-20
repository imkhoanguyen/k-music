using Microsoft.AspNetCore.Identity;
using Music.Core.Authorization;
using Music.Core.Entities;

namespace Music.Infrastructure.DataAccess.SeedData
{
    public class RoleClaimSeed
    {
        public static async Task SeedAsync(MusicContext context, RoleManager<AppRole> roleManager)
        {
            if (context.RoleClaims.Any()) return;

            var adminRole = await roleManager.FindByNameAsync("Admin");
            var adminClaims = AppPermission.adminClaims.Select(claim => new IdentityRoleClaim<string>
            {
                RoleId = adminRole.Id,
                ClaimType = claim.ClaimType,
                ClaimValue = claim.ClaimValue,
            }).ToList();

            await context.RoleClaims.AddRangeAsync(adminClaims);
            await context.SaveChangesAsync();
        }
    }
}
