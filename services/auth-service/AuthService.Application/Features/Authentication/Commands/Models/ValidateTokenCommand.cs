using MediatR;
using AuthService.Application.Bases;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class ValidateTokenCommand : IRequest<Response<TokenValidationResponse>>
    {
        public string AccessToken { get; set; }
    }
}
