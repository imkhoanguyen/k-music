using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KM.Infrastructure.Configuration
{
    public static class Configuration
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            services.AddDbContext<MusicContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<MusicContext>();
        }
    }
}
