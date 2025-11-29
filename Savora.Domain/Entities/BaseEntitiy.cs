using System.ComponentModel.DataAnnotations;

namespace Savora.Domain.Entities
{
    public class BaseEntitiy
    {
        [Key]
        public int Id { get; set; }
    }
}
