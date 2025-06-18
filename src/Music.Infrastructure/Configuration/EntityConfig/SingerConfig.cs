using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Domain.Enum;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class SingerConfig : IEntityTypeConfiguration<Singer>
    {
        public void Configure(EntityTypeBuilder<Singer> builder)
        {
            builder.Property(s => s.Gender).HasConversion(
                g => g.ToString(),
                g => (Gender)Enum.Parse(typeof(Gender), g)
            );
        }
    }
}
