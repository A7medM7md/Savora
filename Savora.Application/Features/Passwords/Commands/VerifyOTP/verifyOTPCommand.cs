

using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Passwords.Commands.VerifyOTP
{
    //[Endpoint(EndpointMethod.Post, EndpointTag.Password, "VerifyOTP")]
    public record verifyOTPCommand(string Email, string OTP) : IRequest<Result>;

    public class VerifyOtpCommandHandler(IPasswordService passwordService) : IRequestHandler<verifyOTPCommand, Result>
    {
        public async Task<Result> Handle(verifyOTPCommand request, CancellationToken cancellationToken)
        {
            return await passwordService.VerifyOtpAsync(request.Email, request.OTP, cancellationToken);
        }
    }
}
