using ExpenseService.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseService.Infrastructure.Persistence.Configurations
{
    internal class UserFinancialProfileConfigurations : IEntityTypeConfiguration<UserFinancialProfile>
    {
        public void Configure(EntityTypeBuilder<UserFinancialProfile> builder)
        {
            builder.Property(u => u.CurrentBalance)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(u => u.MonthlySalary)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        }
    }
}
