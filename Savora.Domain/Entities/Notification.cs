using Savora.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Savora.Domain.Entities
{
    public class Notification : BaseEntitiy
    {
        [Required]
        [MaxLength(500)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
