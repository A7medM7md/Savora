
using Savora.Application.Common.Responses;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Results;

namespace UserService.Services.Abstracts
{
    public interface IRefreshTokenRepository
    {
        Task<Result<RefreshToken>> SaveRefreshTokenAsync(int userId, string token, DateTimeOffset creationDate, DateTimeOffset expiryDate);
        Task<Result> RemoveRefreshTokenAsync(string refreshToken);
        Task<Result<int>> RemoveExpiredTokensAsync();
        Task<RefreshToken?> GetRefreshTokenAsync(string token);
        public Task<Result<TokenData>> GenerateTokensAsync(User user);

    }
}
