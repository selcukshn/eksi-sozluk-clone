using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EntryConfiguration : BaseConfiguration<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Subject).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.Url).HasMaxLength(400).IsRequired();
            builder.Property(e => e.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasMany(e => e.EntryComments).WithOne(e => e.Entry).HasForeignKey(e => e.EntryId);
            builder.HasMany(e => e.EntryFavorites).WithOne(e => e.Entry).HasForeignKey(e => e.EntryId);
            builder.HasMany(e => e.EntryVotes).WithOne(e => e.Entry).HasForeignKey(e => e.EntryId);
        }
    }
}