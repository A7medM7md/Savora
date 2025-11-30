

using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Passwords.Commands.ResetPassword;

//[Authorize]
//[Endpoint(EndpointMethod.Post, EndpointTag.Password, "SendResetPasswordOtp")]
public record SendResetPasswordOTP(string Email) : IRequest<Result>;

public class SendResetPasswordOTPHandler(IPasswordService passwordService) : IRequestHandler<SendResetPasswordOTP, Result>
{
    public Task<Result> Handle(SendResetPasswordOTP request, CancellationToken cancellationToken)
     => passwordService.CreatePasswordResetOtpAsync(email: request.Email);
}
