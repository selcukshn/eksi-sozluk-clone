using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EntryCommentConfiguration : BaseConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasMany(e => e.EntryCommentFavorites).WithOne(e => e.EntryComment).HasForeignKey(e => e.EntryCommentId);
            builder.HasMany(e => e.EntryCommentVotes).WithOne(e => e.EntryComment).HasForeignKey(e => e.EntryCommentId);
        }
    }
}