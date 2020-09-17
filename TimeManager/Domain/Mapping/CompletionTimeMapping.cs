using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeManager.Domain.Mapping
{
    public class CompletionTimeMapping : IEntityTypeConfiguration<CompletionTime>
    {
        public void Configure(EntityTypeBuilder<CompletionTime> builder)
        {
            builder.Property(c => c.Start)
                .IsRequired();

            builder.Property(c => c.End)
                .IsRequired();

            builder.HasOne(c => c.Activity)
                .WithMany(a => a.CompletedHours);
        }
    }
}