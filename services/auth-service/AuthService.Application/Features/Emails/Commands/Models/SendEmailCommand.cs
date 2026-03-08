using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.Email;
using MediatR;

namespace AuthService.Application.Features.Emails.Commands.Models
{
    public class SendEmailCommand : EmailMessage, IRequest<Response<string>>
    {
    }
}
