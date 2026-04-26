using System.ComponentModel.DataAnnotations;

namespace ExpenseService.Domain.Entities.Core
{
    public class UserFinancialProfile : BaseEntity
    {
        public int UserId { get; set; }

        public decimal MonthlySalary { get; set; }


        [Range(1, 31, ErrorMessage = "Salary day must be between 1 and 31.")]
        public int SalaryDay { get; set; }

        public decimal CurrentBalance { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<MonthlyBudget> MonthlyBudgets { get; set; }
    }
}
