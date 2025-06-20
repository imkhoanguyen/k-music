using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;
using Music.Core.Enum;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(s => s.SongType).HasConversion(
                st => st.ToString(),
                st => (SongType)Enum.Parse(typeof(SongType), st)
            );
        }
    }
}
