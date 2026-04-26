using ExpenseService.Domain.Entities.AI;
using ExpenseService.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace ExpenseService.Infrastructure.Persistence.Contexts
{
    public class SavoraExpenseContext(DbContextOptions<SavoraExpenseContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(SavoraExpenseContext).Assembly);
        }


        // Core
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalContribution> GoalContributions { get; set; }
        public DbSet<MonthlyBudget> MonthlyBudgets { get; set; }
        public DbSet<SavingTransaction> SavingTransactions { get; set; }
        public DbSet<UserFinancialProfile> UserFinancialProfiles { get; set; }

        // AI
        public DbSet<FinancialInsight> FinancialInsights { get; set; }
    }
}
