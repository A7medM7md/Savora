using System.ComponentModel.DataAnnotations;

namespace Savora.Domain.Entities.Identity
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Token { get; set; }
        [Required]
        public DateTimeOffset CreationDate { get; set; }
        [Required]
        public DateTimeOffset ExpiryDate { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTimeOffset? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpired;
        private bool IsExpired => DateTime.UtcNow >= ExpiryDate;
        public User User { get; set; }

        public void Revoke()
        {
            if (!IsActive) return;
            RevokedOn = DateTime.UtcNow;
        }
    }
}
