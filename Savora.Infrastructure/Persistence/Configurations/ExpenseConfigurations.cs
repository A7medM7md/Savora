using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savora.Domain.Entities;

namespace Savora.Infrastructure.Persistence.Configurations
{
    public class ExpenseConfigurations : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.OriginalAmount)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(e => e.OriginalCurrency)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(e => e.BaseAmount)
                .HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Priority)
                .HasConversion<string>();
        }
    }
}
