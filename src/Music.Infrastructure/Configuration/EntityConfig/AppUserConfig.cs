using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;
using Music.Core.Enum;

namespace Music.Infrastructure.Configuration.EntityConfig
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
