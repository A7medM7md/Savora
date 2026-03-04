using FluentValidation;
using Microsoft.Extensions.Localization;
using AuthService.Application.Features.Users.Commands.Models;
using AuthService.Application.Resources;

namespace AuthService.Application.Features.Users.Commands.Validators
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {

        #region Fields

        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion


        #region Constructors

        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Handle Functions

        private void ApplyValidationsRules()
        {
            RuleFor(U => U.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(U => U.CurrentPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(U => U.NewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(U => U.ConfirmNewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Equal(U => U.NewPassword).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);

        }


        private void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
