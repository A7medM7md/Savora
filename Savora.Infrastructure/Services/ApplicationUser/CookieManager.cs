using Microsoft.AspNetCore.Http;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Entities.Identity;

namespace Savora.Application.Services.ApplicationUser
{
    class CookieManager(IHttpContextAccessor httpContextAccessor) : ICookieManager
    {
        public void ClearRefreshTokenCookie()
        {
            httpContextAccessor.HttpContext!.Response.Cookies.Delete(nameof(RefreshToken));
        }

        public string? GetRefreshTokenCookie()
        {
            return httpContextAccessor.HttpContext!.Request.Cookies[nameof(RefreshToken)];
        }

        public void SetHttpOnlyCookie(string key, string value, DateTimeOffset expiry)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = expiry,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = false
            };

            httpContextAccessor.HttpContext!.Response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
