using MediatR;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authentication.Queries.Models
{
    public class VerifyResetPasswordCodeQuery : IRequest<Response<bool>>
    {
        public string Email { get; set; }
        public string ResetCode { get; set; }
    }
}
