using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savora.Domain.Entities;

namespace Savora.Application.Persistence.Configurations
{
    public class MonthExpenseConfigurations : IEntityTypeConfiguration<MonthExpense>
    {
        public void Configure(EntityTypeBuilder<MonthExpense> builder)
        {
            builder.Property(me => me.TotalSpent)
                   .HasColumnType("decimal(18, 2)");

            builder.HasMany(me => me.Expenses)
                .WithOne(e => e.MonthExpense)
                .HasForeignKey(e => e.MonthExpenseId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete of expenses when a month is deleted
        }
    }
}
