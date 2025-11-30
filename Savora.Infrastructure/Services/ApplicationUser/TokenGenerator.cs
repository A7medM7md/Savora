using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Savora.Application.Services.ApplicationUser
{
    public class TokenGenerator(JwtSettings jwtSettings, UserManager<User> userManager) : ITokenGenerator
    {
        public async Task<(string Token, DateTimeOffset ExpiryDate)> GenerateAccessToken(User user)
        {
            var expires = DateTimeOffset.Now.AddMinutes(jwtSettings.AccessTokenExpireDate);
            var claims = GetClaims(user);
            var jwt = new JwtSecurityToken(
                issuer: jwtSettings.issuer,
                audience: jwtSettings.audience,
                claims: await claims,
                expires: expires.UtcDateTime,
                signingCredentials: new SigningCredentials(jwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, expires);
        }

        public (string Token, DateTimeOffset CreationDate, DateTimeOffset ExpiryDate) GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomNumber);
                var now = DateTimeOffset.UtcNow;
                return (
                    Convert.ToBase64String(randomNumber),
                    now,
                    now.AddMinutes(jwtSettings.RefreshTokenExpireDate)
                );
            }
        }

        public async Task<IList<Claim>> GetClaims(User user)
        {
            List<Claim> claims = [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

        ];
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        public TokenValidationParameters GetTokenValidationParameters(bool validateLifetime = false) =>
            new TokenValidationParameters()
            {
                ValidateIssuer = jwtSettings.validateIssuer,
                ValidIssuer = jwtSettings.issuer,

                ValidateAudience = jwtSettings.validateAudience,
                ValidAudience = jwtSettings.audience,

                //ClockSkew = TimeSpan.FromMinutes(0),
                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = validateLifetime,
                IssuerSigningKey = jwtSettings.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true
            };
    }
}
