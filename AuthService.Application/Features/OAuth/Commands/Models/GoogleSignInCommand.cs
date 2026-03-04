using AuthService.Application.Helpers.JWT;
using AuthService.Domain.Commons;
using MediatR;

namespace AuthService.Application.Features.OAuth.Commands.Models
{
    public class GoogleSignInCommand : IRequest<Response<SignInResponse>>
    {
        public string IdToken { get; set; } = null!;
    }
}
