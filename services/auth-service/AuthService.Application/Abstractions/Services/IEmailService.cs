using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.Email;

namespace AuthService.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public Task<Response<string>> SendEmailAsync(EmailMessage content, CancellationToken cancellationToken);
    }
}
