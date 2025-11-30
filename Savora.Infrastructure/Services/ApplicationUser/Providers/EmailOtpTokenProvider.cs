using Microsoft.AspNetCore.Identity;
using Savora.Domain.Entities.Identity;
using System.Globalization;

namespace Savora.Application.Services.ApplicationUser.Providers
{
    public class EmailOtpTokenProvider : EmailTokenProvider<User>
    {

        public static string EmailOtpPurpose = "EmailActivation";

        public override async Task<string> GenerateAsync(string purpose, UserManager<User> manager, User user)
        {
            var securityToken = new SecurityToken(await manager.CreateSecurityTokenAsync(user));
            var modifier = await GetUserModifierAsync(purpose, manager, user);
            var code = OtpService.GenerateCode(securityToken, modifier, 6).ToString("D6", CultureInfo.InvariantCulture);
            return code;
        }


        public async Task<string> GenerateOtpTokenAsync(string purpose, UserManager<User> manager, User user)
        {
            var securityToken = new SecurityToken(await manager.CreateSecurityTokenAsync(user));
            var modifier = await GetUserModifierAsync(purpose, manager, user);

            var code = OtpService.GenerateCode(securityToken, modifier, 6).ToString("D6", CultureInfo.InvariantCulture);
            return code;
        }

        public override async Task<bool> ValidateAsync(string purpose, string token, UserManager<User> manager, User user)
        {
            if (!int.TryParse(token, out int code))
            {
                return false;
            }

            var securityToken = new SecurityToken(await manager.CreateSecurityTokenAsync(user));
            var modifier = await GetUserModifierAsync(purpose, manager, user);
            return OtpService.ValidateCode(securityToken, code, modifier, token.Length);
        }
    }

}
