

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Savora.Domain.Entities.Identity;

namespace Savora.Application.Services.ApplicationUser.Providers
{
    public class PasswordResetTokenProvider : IUserTwoFactorTokenProvider<User>
    {
        private readonly IMemoryCache _cache;

        public PasswordResetTokenProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<User> manager, User user)
        {
            return Task.FromResult(true);
        }

        public Task<string> GenerateAsync(string purpose, UserManager<User> manager, User user)
        {
            var otp = Enumerable.Range(1, 6)
                .Select(_ => Random.Shared.Next(0, 9).ToString())
                .Aggregate((acc, num) => acc + num);

            _cache.Set($"PasswordReset-{user.Id}", otp, TimeSpan.FromMinutes(15));

            return Task.FromResult(otp);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<User> manager, User user)
        {
            var otp = _cache.Get<string>($"PasswordReset-{user.Id}");

            if (otp == null)
                return Task.FromResult(false);

            return Task.FromResult(otp == token);
        }
    }
}
