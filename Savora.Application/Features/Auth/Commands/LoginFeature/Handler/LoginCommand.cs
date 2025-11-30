


using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Results;

namespace Savora.Application.Features.Auth.Commands.LoginFeature.Handler;

//[Endpoint(EndpointMethod.Post, EndpointTag.Auth, "Login")]
public record LoginCommand(string Email, string Password) : IRequest<Result<UserSessionDto>>;
public class LoginCommandHandler(IIdentityService identityService)
    : IRequestHandler<LoginCommand, Result<UserSessionDto>>
{

    public async Task<Result<UserSessionDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await identityService.SignIn(request.Email, request.Password);
        return result;
    }
}
