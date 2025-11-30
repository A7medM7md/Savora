



using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Results;

namespace Savora.Application.Features.Auth.Commands.RefreshTokenFeature.Handler;


//[Endpoint(EndpointMethod.Patch, EndpointTag.Auth, "RefreshToken")]
public record RefreshTokenCommand(string accessToken) : IRequest<Result<UserSessionDto>>;
public class RefreshTokenCommandHandler(IIdentityService identityService)
    : IRequestHandler<RefreshTokenCommand, Result<UserSessionDto>>
{

    public async Task<Result<UserSessionDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await identityService.RefreshTokenAsync(request.accessToken);
    }
}
