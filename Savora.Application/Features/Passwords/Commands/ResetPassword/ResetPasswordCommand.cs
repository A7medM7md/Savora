


using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Passwords.Commands.ResetPassword;

//[Authorize]
//[Endpoint(EndpointMethod.Patch, EndpointTag.Password, "ResetPassword")]
public record ResetPasswordCommand(
    string Email,
    string OTP,
    string NewPassword
) : IRequest<Result>;

public class ResetPasswordCommandHandler(IPasswordService passwordService) : IRequestHandler<ResetPasswordCommand, Result>
{
    public Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
     => passwordService.ResetPasswordAsync(request.Email, request.OTP, request.NewPassword, cancellationToken);

}
