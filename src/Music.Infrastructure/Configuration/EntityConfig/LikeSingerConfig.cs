using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class LikeSingerConfig : IEntityTypeConfiguration<LikeSinger>
    {
        public void Configure(EntityTypeBuilder<LikeSinger> builder)
        {
            builder.HasKey(ls => new {ls.SingerId, ls.UserId});
        }
    }
}
