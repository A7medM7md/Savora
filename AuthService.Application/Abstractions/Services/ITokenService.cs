using AuthService.Application.Bases;
using AuthService.Application.Entities.Identity;
using AuthService.Application.Helpers.JWT;

namespace AuthService.Application.Abstractions.Services
{
    public interface ITokenService
    {
        public Task<SignInResponse> GenerateJwtTokenAsync(AppUser user);
        public Task<TokenServiceResult<SignInResponse>> RefreshTokenAsync(string accessToken, string refreshToken);
        public Task<TokenServiceResult<TokenValidationResponse>> ValidateAccessToken(string accessToken, bool ignoreExpiry = false);

    }
}
