using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthService.Application.Entities.Identity;

namespace AuthService.Infrastructure.Persistence.Contexts
{
    public class SmartCRMContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public SmartCRMContext(DbContextOptions<SmartCRMContext> options)
            : base(options)
        {
        }

        // System Entities
        public DbSet<AppUser> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
