using Savora.Domain.Results;

namespace Savora.Application.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage emailMessage);
        Task SendAsync(string to, string subject, string content);
    }
}
