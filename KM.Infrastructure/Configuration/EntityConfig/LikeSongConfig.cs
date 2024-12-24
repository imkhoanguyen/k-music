using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class LikeSongConfig : IEntityTypeConfiguration<LikeSong>
    {
        public void Configure(EntityTypeBuilder<LikeSong> builder)
        {
            builder.HasKey(ls => new { ls.SongId, ls.UserId });
        }
    }
}
