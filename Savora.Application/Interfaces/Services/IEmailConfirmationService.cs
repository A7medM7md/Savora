
using Savora.Application.Common.Responses;
using Savora.Domain.Entities.Identity;

namespace Savora.Application.Interfaces.Services
{
    public interface IEmailConfirmationService
    {
        //   Task<Result> SendEmailConfirmation(int userId);
        Task<Result> SendEmailConfirmation(string email);
        public Task<Result> SendEmailConfirmation(int userId);
        Task<Result> ConfirmEmail(string email, string verificationCode);

        Task<Result> SendChangeEmailOtp(string newEmail, User user);
        Task<Result<string>> ConfirmChangeEmail(User user, string newEmail, string verificationCode);
    }
}
