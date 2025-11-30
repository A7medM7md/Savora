

using FluentValidation;
using Savora.Application.Common.Utility;
using Savora.Domain.Enums;

namespace Savora.Application.Features.Passwords.Commands.ChangePassword;
public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.OldPassword)
            .NotEmpty()
            .WithMessage("Old password is required.")
            .Matches(RegexTemplates.Password)
            .WithMessage("Invalid Password Format.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("New password is required.")
            .Matches(RegexTemplates.Password)
            .WithMessage("Invalid Password Format.");

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty()
            .WithMessage("Confirm password is required.")
            .Equal(x => x.NewPassword)
            .WithErrorCode(ErrorCode.PasswordMismatch.ToString());
    }
}
