using KM.Domain.Entities;
using KM.Domain.Enum;
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
        public DbSet<RankList> RankLists { get; set; }
        public DbSet<VipPlan> VipPlans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SongSinger> SongSingers { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SongSinger>()
                .HasKey(ss => new { ss.SongId, ss.SingerId });

            builder.Entity<SongGenre>()
                .HasKey(sg => new { sg.SongId, sg.GenreId });

            builder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            builder.Entity<LikePlaylist>()
                .HasKey(lp => new { lp.PlaylistId, lp.UserId });

            builder.Entity<LikeSong>()
                .HasKey(ls => new { ls.SongId, ls.UserId });

            builder.Entity<Follower>()
                .HasKey(f => new { f.SingerId, f.UserId });

            builder.Entity<RankList>()
                .HasKey(rl => new { rl.UserId, rl.PlaylistId });

            builder.Entity<Singer>().Property(s => s.Gender).HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );
        }
    }
}
