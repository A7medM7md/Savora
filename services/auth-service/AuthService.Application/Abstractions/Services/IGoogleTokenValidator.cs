using Google.Apis.Auth;

namespace AuthService.Application.Abstractions.Services
{
    public interface IGoogleTokenValidator
    {
        public Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken);
    }
}
