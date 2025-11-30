namespace Savora.Domain.Results
{
    public class TokenData
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public DateTimeOffset AccessTokenExpiry { get; set; }
        public DateTimeOffset RefreshTokenExpiry { get; set; }
    }
}
