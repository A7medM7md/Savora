using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.JWT;
using MediatR;

namespace AuthService.Application.Features.OAuth.Commands.Models
{
    public class GoogleSignInCommand : IRequest<Response<SignInResponse>>
    {
        public string IdToken { get; set; } = null!;
    }
}
