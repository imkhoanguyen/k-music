using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class PlaylistSongConfig : IEntityTypeConfiguration<PlaylistSong>
    {
        public void Configure(EntityTypeBuilder<PlaylistSong> builder)
        {
            builder.HasKey(ps => new { ps.PlaylistId, ps.SongId });
        }
    }
}
