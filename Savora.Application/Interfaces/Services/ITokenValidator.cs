using Savora.Application.Common.Responses;

namespace Savora.Application.Interfaces.Services
{
    public interface ITokenValidator
    {
        Task<Result> ValidateAccessTokenAsync(string accessToken, bool allowExpired = false);
        Task<Result> ValidateRefreshTokenAsync(string refreshToken);
    }
}
