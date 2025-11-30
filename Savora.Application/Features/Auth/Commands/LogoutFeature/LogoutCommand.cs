

using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Auth.Commands.LogoutFeature;

//[Endpoint(EndpointMethod.Get, EndpointTag.Auth, "Logout")]
public record LogoutCommand : IRequest<Result>
{
}
public class LogoutCommandHandler(
    IIdentityService identityService)
    : IRequestHandler<LogoutCommand, Result>
{
    public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        return await identityService.SignOut();
    }
}
