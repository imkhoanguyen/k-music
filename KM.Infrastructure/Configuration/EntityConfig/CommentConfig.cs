using KM.Domain.Entities;
using KM.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KM.Infrastructure.Configuration.EntityConfig
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
               .HasOne(c => c.ParentComment)
               .WithMany(c => c.Replies)
               .HasForeignKey(c => c.ParentCommentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.RelatedType).HasConversion(
               o => o.ToString(),
               o => (CommentType)Enum.Parse(typeof(CommentType), o));
        }
    }
}
