using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class LikePlaylistConfig : IEntityTypeConfiguration<LikePlaylist>
    {
        public void Configure(EntityTypeBuilder<LikePlaylist> builder)
        {
            builder.HasKey(lp => new {lp.PlaylistId, lp.UserId});

            builder.HasOne(lp => lp.AppUser)
               .WithMany()
               .HasForeignKey(lp => lp.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            // Khi xóa playlist, không xóa tự động LikePlaylist để tránh lỗi multiple cascade paths
            // => khi xóa playlist phải tiến hành xóa like playlist thủ công!!!
            builder.HasOne(lp => lp.Playlist)
                   .WithMany(p => p.LikePlaylists)
                   .HasForeignKey(lp => lp.PlaylistId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
