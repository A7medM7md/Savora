using Microsoft.AspNetCore.Identity;

namespace Savora.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        // New field to determine the initial base currency
        public string Address { get; set; }

        // User's base currency (e.g., "EGP", "USD", "EUR"). Initialized based on Address, but user can change it.
        public string BaseCurrency { get; set; } // Default to EGP

        // Monthly salary is the base for automatic income entries
        public decimal MonthlySalary { get; set; }

        // Day of the month the salary is received (1-31)
        public int MonthlyDate { get; set; }

        public bool IsSuspended { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public void ConfirmEmail() => EmailConfirmed = true;

        // Navigation properties
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<MonthExpense> MonthExpenses { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
