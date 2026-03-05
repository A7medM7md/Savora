using FluentValidation;
using Microsoft.Extensions.Localization;
using AuthService.Application.Features.Emails.Commands.Models;
using AuthService.Application.Resources;

namespace AuthService.Application.Features.Emails.Commands.Validators
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion


        #region Constructors

        public SendEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }

        #endregion


        #region Handle Functions

        private void ApplyValidationsRules()
        {

            RuleFor(e => e.To)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
               .EmailAddress().WithMessage(_localizer[SharedResourcesKeys.InvalidEmail]);

        }

        #endregion

    }
}
