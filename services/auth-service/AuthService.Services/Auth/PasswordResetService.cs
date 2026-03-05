using Microsoft.AspNetCore.Identity;
using AuthService.Application.Abstractions;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Entities.Identity;
using AuthService.Application.Helpers.Email;
using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.Email.UserService.Infrastructure.Services;
using AuthService.Infrastructure.Persistence.Contexts;
using System.Net;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace AuthService.Services.Auth
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly SmartCRMContext _context;

        public PasswordResetService(UserManager<AppUser> userManager,
            IEmailService emailService,
            SmartCRMContext Context)
        {
            _userManager = userManager;
            _emailService = emailService;
            _context = Context;
        }

        public async Task<Response<string>> GenerateAndSendResetCodeAsync(string email, CancellationToken cancellationToken)
        {
            // Get User
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return Response<string>.Fail("user not found", HttpStatusCode.NotFound);

            // Generate Code
            var code = GenerateOTP(6);

            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                // Update User Reset Code In DB
                user.ResetCode = code; // Stored Hashed Automatically
                user.ResetCodeExpiry = DateTime.UtcNow.AddMinutes(15);
                var updateResult = await _userManager.UpdateAsync(user);

                // Send Code To User Email

                var emailMessage = new EmailMessage
                {
                    To = user.Email!,
                    Subject = "Password Reset",
                    Content = EmailTemplateBuilder.BuildResetPasswordEmail(code, user.FullName),
                    IsHtml = true
                };

                // Send Confirmation Email
                var sendResult = await _emailService.SendEmailAsync(emailMessage, cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return Response<string>.Success("Reset code sent to email");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return Response<string>.Fail(ex.Message, "Failed to generate reset code", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Response<bool>> VerifyResetCodeAsync(string email, string code)
        {
            var (_, error) = await ValidateResetCodeAsync(email, code);
            if (error != null) return error;
            return Response<bool>.Success(true);
        }

        public async Task<Response<bool>> ResetPasswordAsync(string email, string code, string newPassword)
        {
            var (user, error) = await ValidateResetCodeAsync(email, code); // Validate Again For Security
            if (error != null) return error;

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Remove old password
                var removeResult = await _userManager.RemovePasswordAsync(user);
                // Add new password
                var addResult = await _userManager.AddPasswordAsync(user, newPassword);

                // Clear OTP for one-time usage
                user.ResetCode = null;
                user.ResetCodeExpiry = null;
                await _userManager.UpdateAsync(user);

                await transaction.CommitAsync();

                return Response<bool>.Success(true);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Response<bool>.Fail(ex.Message, "Failed to reset password", HttpStatusCode.InternalServerError);
            }
        }


        // Shared validation logic
        private async Task<(AppUser user, Response<bool> error)> ValidateResetCodeAsync(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return (null!, Response<bool>.Fail("User not found", HttpStatusCode.NotFound));

            if (user.ResetCodeExpiry < DateTime.UtcNow)
            {
                user.ResetCode = null;
                user.ResetCodeExpiry = null;
                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                    return (null!, Response<bool>.Fail(
                        "Failed to clear expired reset code",
                        HttpStatusCode.InternalServerError,
                        updateResult.Errors.Select(e => e.Description).ToList()
                    ));

                return (null!, Response<bool>.Fail("Reset code expired", HttpStatusCode.BadRequest));
            }

            if (user.ResetCode != code)
                return (null!, Response<bool>.Fail("Invalid reset code", HttpStatusCode.BadRequest));

            return (user, null!);
        }

        private string GenerateOTP(int length)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            rng.GetBytes(bytes);

            var result = "";
            foreach (var b in bytes)
                result += (b % 10).ToString();

            return result;
        }

    }
}
