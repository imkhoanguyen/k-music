using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Music.Core.Entities;

namespace Music.Infrastructure.DataAccess.SeedData
{
    public class RoleSeed
    {
        public static async Task SeedAsync(RoleManager<AppRole> roleManager)
        {
            if (await roleManager.Roles.AnyAsync()) return;

            var roles = new List<AppRole>
            {
                new() { Name = "Admin", Description = "Access all permission" },
                new() { Name = "Customer", Description = "Normal user" },
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
