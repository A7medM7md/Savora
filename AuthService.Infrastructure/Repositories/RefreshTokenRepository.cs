using Microsoft.EntityFrameworkCore;
using AuthService.Application.Abstractions.Repositories;
using AuthService.Application.Entities.Identity;
using AuthService.Infrastructure.Persistence.Contexts;

namespace AuthService.Infrastructure.Repositories
{
    internal class RefreshTokenRepository : GenericRepositoryAsync<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SmartCRMContext dbContext) : base(dbContext)
        {
        }

        public async Task<RefreshToken?> GetByTokenAsync(string refreshToken)
        {

            return await GetTableNoTracking()
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

        }

    }
}
