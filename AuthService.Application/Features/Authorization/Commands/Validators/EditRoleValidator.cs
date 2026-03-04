using FluentValidation;
using Microsoft.Extensions.Localization;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Features.Authorization.Commands.Models;
using AuthService.Application.Resources;

namespace AuthService.Application.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion


        #region Constructors

        public EditRoleValidator(IStringLocalizer<SharedResources> localizer,
            IAuthorizationService authorizationService)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Handle Functions

        private void ApplyValidationsRules()
        {
            RuleFor(R => R.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(R => R.RoleName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(R => R.RoleName)
                .MustAsync(async (Model, Key, CancellationToken) => !await _authorizationService.IsRoleExist(Key, Model.Id))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }

        #endregion
    }
}
