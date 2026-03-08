using ExpenseService.Domain.Helpers.Enums;

namespace ExpenseService.Domain.Entities.AI
{
    public class FinancialInsight : BaseEntity
    {
        public int UserId { get; set; }

        public string InsightText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public InsightType Type { get; set; }
    }
}
