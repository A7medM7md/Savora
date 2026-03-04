using MediatR;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCodeCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
