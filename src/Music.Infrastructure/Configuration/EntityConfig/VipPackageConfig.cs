using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class VipPackageConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(vp => vp.Price).HasColumnType("decimal(18,2)");
            builder.Property(vp => vp.PriceSell).HasColumnType("decimal(18,2)");
        }
    }
}
