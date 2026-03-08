using ExpenseService.Domain.Helpers.Enums;

namespace ExpenseService.Domain.Entities.Core
{
    public class Expense : BaseEntity
    {
        public int MonthlyBudgetId { get; set; }

        public decimal Amount { get; set; }

        public string Title { get; set; }

        public ExpensePriority Priority { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public ExpenseCategory Category { get; set; }
    }
}
