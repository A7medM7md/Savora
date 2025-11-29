using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savora.Domain.Entities;

namespace Savora.Infrastructure.Persistence.Configurations
{
    public class GoalConfigurations : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.Property(g => g.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(g => g.MoneyTarget)
                     .HasColumnType("decimal(18, 2)");
        }
    }
}
