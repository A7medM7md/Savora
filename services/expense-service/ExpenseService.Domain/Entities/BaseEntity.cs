using System.ComponentModel.DataAnnotations;

namespace ExpenseService.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
