using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.JWT;
using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<SignInResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
