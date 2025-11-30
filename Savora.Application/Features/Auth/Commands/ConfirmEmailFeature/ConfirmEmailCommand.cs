

using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;

namespace Savora.Application.Features.Auth.Commands.ConfirmEmailFeature;

//[Endpoint(EndpointMethod.Patch, EndpointTag.Email, "ConfirmEmail")]
public record ConfirmEmailCommand(string Email, string VerificationCode) : IRequest<Result>;
public class ConfirmEmailCommandHandler(
    IEmailConfirmationService emailConfirmationService)
    : IRequestHandler<ConfirmEmailCommand, Result>
{
    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        return await emailConfirmationService.ConfirmEmail(request.Email, request.VerificationCode);
    }
}
