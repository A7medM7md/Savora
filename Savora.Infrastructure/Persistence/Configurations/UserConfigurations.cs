using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savora.Domain.Entities;

namespace Savora.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Address)
                .HasMaxLength(255);

            builder.Property(u => u.BaseCurrency)
                .IsRequired()
                .HasMaxLength(3)
                .HasDefaultValue("EGP");

            builder.Property(u => u.MonthlySalary)
                .HasColumnType("decimal(18, 2)");

            builder.Property(u => u.MonthlyDate)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                name: "CK_User_MonthlyDate_Range",
                sql: "[MonthlyDate] >= 1 AND [MonthlyDate] <= 31"
            ));


            builder.HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);

            builder.HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.HasMany(u => u.MonthExpenses)
                .WithOne(me => me.User)
                .HasForeignKey(me => me.UserId);

            builder.HasMany(u => u.Incomes)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);

            builder.HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);
        }
    }
}
