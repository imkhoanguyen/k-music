using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class PlaylistSongConfig : IEntityTypeConfiguration<PlaylistSong>
    {
        public void Configure(EntityTypeBuilder<PlaylistSong> builder)
        {
            builder.HasKey(ps => new { ps.PlaylistId, ps.SongId });
        }
    }
}
