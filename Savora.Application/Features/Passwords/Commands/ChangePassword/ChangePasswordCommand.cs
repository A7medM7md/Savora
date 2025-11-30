

using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Passwords.Commands.ChangePassword;

//[Authorize]
//[Endpoint(EndpointMethod.Patch, EndpointTag.Password, "ChangePassword")]
public record ChangePasswordCommand(string OldPassword, string NewPassword, string ConfirmNewPassword) : IRequest<Result>;

public class ChangePasswordCommandHandler(IPasswordService passwordService) : IRequestHandler<ChangePasswordCommand, Result>
{
    public Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        => passwordService.ChangePasswordAsync(request.OldPassword, request.NewPassword, request.ConfirmNewPassword, cancellationToken);
}
