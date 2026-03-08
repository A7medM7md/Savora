namespace ExpenseService.Domain.Entities.Core
{
    public class Goal : BaseEntity
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsCompleted { get; set; }

        public ICollection<GoalContribution> Contributions { get; set; }
    }
}
