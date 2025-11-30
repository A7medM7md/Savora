
//done
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Enums;
using Savora.Domain.Results;

namespace Savora.Application.Services.ApplicationUser
{
    public class EmailConfirmationService(UserManager<User> userManager, ITokenGenerator tokenGenerator, IEmailSender emailSender) : IEmailConfirmationService
    {
        public async Task<Result> SendEmailConfirmation(string email)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email!.ToLower() == email.ToLower());

            if (user is null) return ErrorCode.UnregisteredEmail;

            var tokenOtp = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailMessage = new EmailMessage
            {
                To = email,
                Subject = "Email Confirmation",
                Content = EmailTemplateBuilder.BuildTokenEmail(tokenOtp, user.Name),
                IsHtml = true
            };
            await emailSender.SendAsync(emailMessage);
            return Result.Success();

        }

        public async Task<Result> SendEmailConfirmation(int userId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null) return ErrorCode.UnregisteredEmail;

            var tokenOtp = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailMessage = new EmailMessage
            {
                To = user.Email,
                Subject = "Email Confirmation",
                Content = EmailTemplateBuilder.BuildTokenEmail(tokenOtp, user.Name),
                IsHtml = true
            };
            await emailSender.SendAsync(emailMessage);
            return Result.Success();

        }
        public async Task<Result> ConfirmEmail(string email, string verificationCode)
        {
            var user = await userManager.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email!.ToLower() == email.ToLower());

            if (user is null) return ErrorCode.UnregisteredEmail;

            var confirmationResults = await userManager.ConfirmEmailAsync(user, verificationCode);

            if (!confirmationResults.Succeeded)
            {
                var firstError = confirmationResults.Errors.Select(e => e.Description).FirstOrDefault() ?? "An error occurred during email confirmation.";
                return new Error(ErrorCode.ExternalProviderError, firstError);
            }
            return Result.Success();
        }

        public async Task<Result> SendChangeEmailOtp(string newEmail, User user)
        {
            var otp = await userManager.GenerateOtpTokenAsync("ChangeEmail", user);
            var emailMessage = new EmailMessage
            {
                To = newEmail,
                Subject = "Change Email Confirmation",
                Content = EmailTemplateBuilder.BuildTokenEmail(otp, user.Name),
                IsHtml = true
            };
            await emailSender.SendAsync(emailMessage);
            return Result.Success();
        }



        public async Task<Result<string>> ConfirmChangeEmail(User user, string newEmail, string verificationCode)
        {

            var otp = await userManager.GenerateOtpTokenAsync("ChangeEmail", user);

            if (otp == verificationCode)
            {
                var token = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
                var res = await userManager.ChangeEmailAsync(user, newEmail, token);

                if (!res.Succeeded)
                {
                    return new Error(ErrorCode.ExternalProviderError, res.Errors.Select(e => e.Description).FirstOrDefault() ?? "An error occurred during email change.");
                }
            }
            else
            {
                return ErrorCode.InvalidToken;
            }


            var newToken = await tokenGenerator.GenerateAccessToken(user);

            return newToken.Token;


        }
    }
}
