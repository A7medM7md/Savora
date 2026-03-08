namespace ExpenseService.Domain.Entities.Core
{
    public class UserFinancialProfile : BaseEntity
    {
        public int UserId { get; set; }

        public decimal MonthlySalary { get; set; }

        public int SalaryDay { get; set; }

        public decimal CurrentBalance { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<MonthlyBudget> MonthlyBudgets { get; set; }
    }
}
