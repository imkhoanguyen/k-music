using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;

namespace Music.Infrastructure.Configuration.EntityConfig
{
    public class UserVipSubcriptionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(uvs => uvs.Price).HasColumnType("decimal(18,2)");
        }
    }
}
