using MediatR;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;


namespace Savora.Application.Features.Auth.Commands.SendEmailConfirmationFeature.Handler;

//[Endpoint(EndpointMethod.Get, EndpointTag.Email, "SendConfirmationEmail")]
public record SendEmailConfirmationCommand : IRequest<Result>
{
    [EmailAddress]
    public required string Email { get; set; }
}
public class SendEmailConfirmationCommandHandler(
    IEmailConfirmationService emailConfirmationService)
    : IRequestHandler<SendEmailConfirmationCommand, Result>
{
    public async Task<Result> Handle(SendEmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        return await emailConfirmationService.SendEmailConfirmation(request.Email);
    }
}

