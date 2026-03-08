namespace ExpenseService.Domain.Entities.Core
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public bool IsSystem { get; set; }
    }
}
