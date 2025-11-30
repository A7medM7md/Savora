


using FluentValidation;
using Savora.Application.Common.Utility;
using Savora.Domain.Enums;

namespace Savora.Application.Features.Auth.Commands.ConfirmChangeEmail;
internal class ConfirmChangeEmailValidator : AbstractValidator<ConfirmChangeEmailCommand>
{
    public ConfirmChangeEmailValidator()
    {
        RuleFor(x => x.VerificationCode)
            .NotEmpty()
            .Length(6);

        RuleFor(x => x.Email).NotEmpty()
            .WithMessage(ErrorCode.RequiredFieldMissing.ToString())
            .Matches(RegexTemplates.Email)
            .WithErrorCode(ErrorCode.InvalidEmailFormat.ToString());
    }
}
