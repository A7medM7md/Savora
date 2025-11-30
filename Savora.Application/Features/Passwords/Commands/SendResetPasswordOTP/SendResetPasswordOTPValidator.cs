

using FluentValidation;
using Savora.Application.Common.Utility;

namespace Savora.Application.Features.Passwords.Commands.ResetPassword;
public class SendResetPasswordOTPValidator : AbstractValidator<SendResetPasswordOTP>
{
    public SendResetPasswordOTPValidator()
    {
        RuleFor(x => x.Email)
            .Matches(RegexTemplates.Email)
            .WithMessage("Invalid email format.");

    }
}
