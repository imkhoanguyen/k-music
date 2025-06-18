using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class LikeSingerConfig : IEntityTypeConfiguration<LikeSinger>
    {
        public void Configure(EntityTypeBuilder<LikeSinger> builder)
        {
            builder.HasKey(ls => new {ls.SingerId, ls.UserId});
        }
    }
}
