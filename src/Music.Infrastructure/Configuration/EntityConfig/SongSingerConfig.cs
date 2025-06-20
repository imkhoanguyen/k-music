using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class SongSingerConfig : IEntityTypeConfiguration<SongSinger>
    {
        public void Configure(EntityTypeBuilder<SongSinger> builder)
        {
            builder.HasKey(ss => new { ss.SongId, ss.SingerId });
        }
    }
}
