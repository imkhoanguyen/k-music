﻿using KM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class RoleSeed
    {
        public static async Task SeedAsync(RoleManager<AppRole> roleManager)
        {
            if (roleManager.Roles.Any()) return;

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