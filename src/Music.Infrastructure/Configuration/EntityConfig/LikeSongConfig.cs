using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class LikeSongConfig : IEntityTypeConfiguration<LikeSong>
    {
        public void Configure(EntityTypeBuilder<LikeSong> builder)
        {
            builder.HasKey(ls => new { ls.SongId, ls.UserId });
        }
    }
}
