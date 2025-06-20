using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Entities;
using Music.Core.Enum;

namespace Music.Infrastructure.Configuration.EntityConfig
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
