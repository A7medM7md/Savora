using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
