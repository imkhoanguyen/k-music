using KM.Domain.Entities;
using KM.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.Gender).HasConversion(
               o => o.ToString(),
               o => (Gender)Enum.Parse(typeof(Gender), o));
        }
    }
}
