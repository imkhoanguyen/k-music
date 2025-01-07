using KM.Domain.Entities;
using KM.Domain.Enum;
using KM.Infrastructure.Configuration.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess
{
    public class MusicContext : IdentityDbContext<AppUser>
    {
        public MusicContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<VipPackage> VipPackages { get; set; }
        public DbSet<UserVipSubscription> UserVipSubscriptions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SongSinger> SongSingers { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SingerConfig).Assembly);
        }
    }
}
