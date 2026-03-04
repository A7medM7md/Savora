using MediatR;
using Microsoft.Extensions.Localization;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Bases;
using AuthService.Application.Features.Authorization.Queries.Models;
using AuthService.Application.Features.Authorization.Queries.Responses;
using AuthService.Application.Resources;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Queries.Handlers
{
    public class ClaimQueryHandler : ResponseHandler,
                                        IRequestHandler<GetClaimsForUserQuery, Response<GetClaimsForUserResponse>>
    {
        private readonly IAuthorizationService _authorizationService;

        public ClaimQueryHandler(IAuthorizationService authorizationService,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
        }


        public async Task<Response<GetClaimsForUserResponse>> Handle(GetClaimsForUserQuery request, CancellationToken cancellationToken)
        {
            var claimsResponse = await _authorizationService.GetClaimsForUserAsync(request.UserId);

            if (!claimsResponse.Succeeded)
            {
                return Response<GetClaimsForUserResponse>.Fail(
                    message: claimsResponse.Message,
                    statusCode: claimsResponse.StatusCode,
                    errors: claimsResponse.Errors
                );
            }

            var result = new GetClaimsForUserResponse
            {
                UserId = request.UserId,
                Claims = claimsResponse.Data
            };

            return Success(result);
        }
    }
}
