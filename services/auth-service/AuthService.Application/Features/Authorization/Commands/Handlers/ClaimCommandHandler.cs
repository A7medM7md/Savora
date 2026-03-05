using MediatR;
using Microsoft.Extensions.Localization;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Bases;
using AuthService.Application.Features.Authorization.Commands.Models;
using AuthService.Application.Resources;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Commands.Handlers
{
    public class ClaimCommandHandler : ResponseHandler,
                                    IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ClaimCommandHandler(IAuthorizationService authorizationService,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaimsAsync(request.UserId, request.Claims);

            if (!result.Succeeded)
                return BadRequest<string>(IdentityErrorHelper.LocalizeErrors(result.Errors, _stringLocalizer));

            return Success("Claims Updated Successfully");
        }
    }
}
