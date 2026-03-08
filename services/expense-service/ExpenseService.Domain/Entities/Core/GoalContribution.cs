namespace ExpenseService.Domain.Entities.Core
{
    public class GoalContribution : BaseEntity
    {
        public int GoalId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
