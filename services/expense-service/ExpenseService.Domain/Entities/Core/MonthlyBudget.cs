namespace ExpenseService.Domain.Entities.Core
{
    public class MonthlyBudget : BaseEntity
    {
        public int UserFinancialProfileId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal SalaryAmount { get; set; }

        public decimal TotalSpent { get; set; }

        public decimal TotalSaved { get; set; }

        public bool IsClosed { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public ICollection<SavingTransaction> Savings { get; set; }
    }
}
