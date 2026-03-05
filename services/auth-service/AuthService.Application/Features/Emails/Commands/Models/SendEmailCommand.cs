using MediatR;
using AuthService.Application.Helpers.Email;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Emails.Commands.Models
{
    public class SendEmailCommand : EmailMessage, IRequest<Response<string>>
    {
    }
}
