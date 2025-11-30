

using Savora.Application.Common.Responses;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Results;

namespace Savora.Application.Interfaces.Services
{
    public interface ITokensService
    {
        Task<Result<TokenData>> GenerateTokensAsync(User user);
        Task<Result> RemoveRefreshTokenAsync();
        Task<Result<int>> RemoveExpiredTokensAsync();
        Task<Result<TokenData>> RefreshAsync(string accessToken);
    }
}
