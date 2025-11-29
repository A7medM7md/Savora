using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Savora.Domain.Entities;
using System.Reflection;

namespace Savora.Infrastructure.Persistence.Contexts
{
    public class SavoraContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public SavoraContext(DbContextOptions<SavoraContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<MonthExpense> MonthExpenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
