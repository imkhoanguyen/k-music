using KM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class UserSeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var users = new List<AppUser>
            {
                new AppUser
                {
                    FullName = "Nguyễn Anh Khoa",
                    UserName = "Admin",
                    Email = "khoanguyen.coder@gmail.com",
                    Gender = Domain.Enum.Gender.Male,
                    PhoneNumber = "0985576590",
                    ImgUrl = @"https://avatars.githubusercontent.com/u/142555542?v=4"
                },
                new AppUser
                {
                    FullName = "Nguyễn Văn B",
                    UserName = "Customer",
                    Email = "itk21sgu@gmail.com",
                    Gender = Domain.Enum.Gender.Male,
                    PhoneNumber = "0147258369",
                    ImgUrl = @"https://i.imgur.com/8fLSjJf_d.webp?maxwidth=760&fidelity=grand"
                }
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Admin_123");
            }

            var adminUser = await userManager.FindByNameAsync("Admin");

            await userManager.AddToRoleAsync(adminUser, "Admin");

            var customerUser = await userManager.FindByNameAsync("Customer");

            await userManager.AddToRoleAsync(customerUser, "Customer");
        }
    }
}
