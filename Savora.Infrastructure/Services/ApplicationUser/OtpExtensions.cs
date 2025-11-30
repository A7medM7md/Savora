

using Microsoft.AspNetCore.Identity;
using Savora.Domain.Entities.Identity;

namespace Savora.Application.Services.ApplicationUser
{
    public static class OtpExtensions
    {
        public static async Task<string> GenerateOtpTokenAsync(this UserManager<User> manager,
            string purpose, User user)
        {
            var tokenProvider = new EmailOtpTokenProvider();
            return await tokenProvider.GenerateOtpTokenAsync(purpose, manager, user);
        }
    }
}
