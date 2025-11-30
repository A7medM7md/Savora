using Savora.Domain.Entities.Identity;

namespace Savora.Domain.Entities
{
    public class MonthExpense : BaseEntitiy
    {
        // The month and year this record is for (e.g., 2025-11-01)
        public DateTime Month { get; set; }

        // Total spent in the user's BaseCurrency for the month
        public decimal TotalSpent { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for the expenses in this month (One-to-Many)
        public ICollection<Expense> Expenses { get; set; }
    }
}
