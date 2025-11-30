

using FluentValidation;
using Savora.Application.Common.Utility;
using Savora.Domain.Enums;

namespace Savora.Application.Features.Auth.Commands.ConfirmEmailFeature;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithErrorCode(ErrorCode.InvalidInput.ToString())
            .Matches(RegexTemplates.Email).WithErrorCode(ErrorCode.InvalidEmailFormat.ToString());


        /* RuleFor(x => x.VerificationCode)
             .NotEmpty().WithErrorCode(ErrorCode.InvalidInput.ToString())
             .Matches(RegexTemplates.Otp).WithErrorCode(ErrorCode.InvalidToken.ToString());*/
    }

}
