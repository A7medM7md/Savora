using Savora.Domain.Entities.Identity;
using Savora.Domain.Enums;

namespace Savora.Domain.Entities
{
    public class Expense : BaseEntitiy
    {
        public string Title { get; set; }

        // Priority is enum (e.g., Low, Medium, High)
        public ExpensePriority Priority { get; set; }

        public DateTime Date { get; set; }

        // The amount in the currency it was paid in
        public decimal OriginalAmount { get; set; }

        // The currency of the original amount (e.g., "JPY", "EUR")
        public string OriginalCurrency { get; set; }

        // The amount converted to the user's BaseCurrency
        public decimal BaseAmount { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key to MonthExpense (Many-to-One)
        public int MonthExpenseId { get; set; }
        public MonthExpense MonthExpense { get; set; }
    }
}
