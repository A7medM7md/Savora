namespace ExpenseService.Domain.Entities.Core
{
    public class SavingTransaction : BaseEntity
    {
        public int MonthlyBudgetId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}
