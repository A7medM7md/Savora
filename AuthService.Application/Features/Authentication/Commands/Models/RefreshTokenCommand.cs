using MediatR;
using AuthService.Application.Helpers.JWT;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<SignInResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
