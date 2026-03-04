using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Country { get; set; }
        //[EncryptColumn]
        public string? ResetCode { get; set; } // If you want it hashed, Enable EncryptColumn
        public DateTime? ResetCodeExpiry { get; set; }

        // External Auth Properties (Custom Properties Here - Just For Testing and Development, No Need Now - There Is a Whole Table For This)
        //public string Provider { get; set; } = null!; // e.g., Google, Facebook
        //public string ProviderId { get; set; } = null!;

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    }
}
