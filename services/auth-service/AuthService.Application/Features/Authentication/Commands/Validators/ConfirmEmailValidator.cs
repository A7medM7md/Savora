using FluentValidation;
using Microsoft.Extensions.Localization;
using AuthService.Application.Features.Authentication.Commands.Models;
using AuthService.Application.Resources;

namespace AuthService.Application.Features.Authentication.Commands.Validators
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public ConfirmEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(U => U.UserId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(U => U.Token)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

    }
}
