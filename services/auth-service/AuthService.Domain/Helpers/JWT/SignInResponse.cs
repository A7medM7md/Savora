namespace AuthService.Application.Helpers.JWT
{
    public class SignInResponse
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public RefreshTokenResponse RefreshToken { get; set; }
    }

    public class RefreshTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }

    }
}
