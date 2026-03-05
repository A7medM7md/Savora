using AuthService.Application.Abstractions.Services;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;

namespace AuthService.Services.OAuth
{
    public class GoogleTokenValidator : IGoogleTokenValidator
    {
        private readonly string _clientId;

        public GoogleTokenValidator(IConfiguration config)
        {
            _clientId = config["GoogleAuth:ClientId"]
                  ?? throw new InvalidOperationException("Google ClientId is not configured");
        }

        public async Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _clientId }
            };

            return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        }
    }

}
