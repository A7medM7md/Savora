using AuthService.Application.Helpers.Email;
using AuthService.Domain.Commons;

namespace AuthService.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public Task<Response<string>> SendEmailAsync(EmailMessage content, CancellationToken cancellationToken);
    }
}
