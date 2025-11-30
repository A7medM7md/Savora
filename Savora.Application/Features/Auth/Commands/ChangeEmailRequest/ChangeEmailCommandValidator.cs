

using FluentValidation;
using Savora.Application.Common.Utility;
using Savora.Domain.Enums;

namespace Savora.Application.Features.Auth.Commands.ChangeEmail;
public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
{
    public ChangeEmailCommandValidator()
    {
        RuleFor(x => x.NewEmail)
            .NotEmpty()
            .WithMessage(ErrorCode.RequiredFieldMissing.ToString())
            .Matches(RegexTemplates.Email)
            .WithErrorCode(ErrorCode.InvalidEmailFormat.ToString());
        RuleFor(x => x.CurrentEmail)
            .NotEmpty()
            .WithMessage(ErrorCode.RequiredFieldMissing.ToString())
            .Matches(RegexTemplates.Email)
            .WithErrorCode(ErrorCode.InvalidEmailFormat.ToString());
        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .WithMessage(ErrorCode.RequiredFieldMissing.ToString());

    }
}
