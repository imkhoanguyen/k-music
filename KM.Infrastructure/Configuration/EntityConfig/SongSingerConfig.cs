using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class SongSingerConfig : IEntityTypeConfiguration<SongSinger>
    {
        public void Configure(EntityTypeBuilder<SongSinger> builder)
        {
            builder.HasKey(ss => new { ss.SongId, ss.SingerId });
        }
    }
}
