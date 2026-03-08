using AuthService.Domain.Entities.Identity;

namespace AuthService.Application.Abstractions.Repositories
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<RefreshToken>
    {
        public Task<RefreshToken?> GetByTokenAsync(string refreshToken);
    }
}
