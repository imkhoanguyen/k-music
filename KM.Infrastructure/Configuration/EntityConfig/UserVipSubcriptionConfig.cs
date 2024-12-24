using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class UserVipSubcriptionConfig : IEntityTypeConfiguration<UserVipSubscription>
    {
        public void Configure(EntityTypeBuilder<UserVipSubscription> builder)
        {
            builder.Property(uvs => uvs.Price).HasColumnType("decimal(18,2)");
        }
    }
}
