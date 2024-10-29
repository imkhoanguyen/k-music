using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Application.Service.Implementation;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Repositories;
using KM.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KM.Infrastructure.Configuration
{
    public static class Configuration
    {
        // register database
        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            services.AddDbContext<MusicContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<MusicContext>();
        }

        // register dependencies injection
        public static void RegisterDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
        }
    }
}
