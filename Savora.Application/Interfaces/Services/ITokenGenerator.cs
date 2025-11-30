
using Microsoft.IdentityModel.Tokens;
using Savora.Domain.Entities.Identity;
using System.Security.Claims;

namespace Savora.Application.Interfaces.Services
{
    public interface ITokenGenerator
    {
        Task<(string Token, DateTimeOffset ExpiryDate)> GenerateAccessToken(User user);
        (string Token, DateTimeOffset CreationDate, DateTimeOffset ExpiryDate) GenerateRefreshToken();
        Task<IList<Claim>> GetClaims(User user);
        TokenValidationParameters GetTokenValidationParameters(bool validateLifetime = false);
    }

}
