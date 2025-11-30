using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savora.Domain.Entities;

namespace Savora.Application.Persistence.Configurations
{
    public class IncomeConfigurations : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.Property(i => i.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(i => i.OriginalAmount)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(i => i.OriginalCurrency)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(i => i.BaseAmount)
                .HasColumnType("decimal(18, 2)");

            builder.Property(i => i.Type)
                .HasConversion<string>();
        }
    }
}
