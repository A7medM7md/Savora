namespace Savora.Application.Interfaces.Services
{
    public interface ICookieManager
    {
        void SetHttpOnlyCookie(string key, string value, DateTimeOffset expiry);
        string? GetRefreshTokenCookie();
        void ClearRefreshTokenCookie();
    }
}
