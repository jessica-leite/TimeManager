using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeManager.Domain.Mapping
{
    public class ActivityItemMapping : IEntityTypeConfiguration<ActivityItem>
    {
        public void Configure(EntityTypeBuilder<ActivityItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Start)
                .IsRequired();

            builder.Property(c => c.End)
                .IsRequired();

            builder.HasOne(c => c.Activity)
                .WithMany(a => a.ActivityItems);
        }
    }
}