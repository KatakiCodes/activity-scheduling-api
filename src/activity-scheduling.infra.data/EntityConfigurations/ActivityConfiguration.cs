using activity_scheduling.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace activity_scheduling.infra.data.EntityConfigurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();
        }
    }
}