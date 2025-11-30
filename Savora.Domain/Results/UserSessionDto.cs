namespace Savora.Domain.Results
{
    public class UserSessionDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public required string Email { get; set; }
        public required string AccessToken { get; set; }
        public DateTimeOffset AccessTokenExpDate { get; set; }
        public DateTimeOffset RefreshTokenExpDate { get; set; }
    }
}
