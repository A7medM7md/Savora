using MediatR;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class ConfirmEmailCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
