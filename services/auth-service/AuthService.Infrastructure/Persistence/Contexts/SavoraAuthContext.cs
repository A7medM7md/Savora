using AuthService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Persistence.Contexts
{
    public class SavoraAuthContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public SavoraAuthContext(DbContextOptions<SavoraAuthContext> options)
            : base(options)
        {
        }

        // System Entities
        public DbSet<AppUser> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
