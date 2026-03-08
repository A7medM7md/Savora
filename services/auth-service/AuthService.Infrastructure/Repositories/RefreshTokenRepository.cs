using AuthService.Application.Abstractions.Repositories;
using AuthService.Domain.Entities.Identity;
using AuthService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories
{
    internal class RefreshTokenRepository : GenericRepositoryAsync<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SavoraAuthContext dbContext) : base(dbContext)
        {
        }

        public async Task<RefreshToken?> GetByTokenAsync(string refreshToken)
        {

            return await GetTableNoTracking()
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

        }

    }
}
