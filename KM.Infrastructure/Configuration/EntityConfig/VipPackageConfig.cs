using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class VipPackageConfig : IEntityTypeConfiguration<VipPackage>
    {
        public void Configure(EntityTypeBuilder<VipPackage> builder)
        {
            builder.Property(vp => vp.Price).HasColumnType("decimal(18,2)");
            builder.Property(vp => vp.PriceSell).HasColumnType("decimal(18,2)");
        }
    }
}
