using FluentValidation;
using Microsoft.Extensions.Localization;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Features.Authorization.Commands.Models;
using AuthService.Application.Resources;

namespace AuthService.Application.Features.Authorization.Commands.Validators
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion


        #region Constructors

        public AddRoleValidator(IStringLocalizer<SharedResources> localizer,
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
            RuleFor(R => R.RoleName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(R => R.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }

        #endregion
    }
}
