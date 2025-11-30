


using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Enums;

namespace Savora.Application.Features.Auth.Commands.ConfirmChangeEmail;

//[Authorize]
//[Endpoint(EndpointMethod.Patch, EndpointTag.Email, "ConfirmChangeEmail")]
public record ConfirmChangeEmailCommand(string Email, string VerificationCode) : IRequest<Result<string>>;
public class ConfirmChangeEmailCommandHandler(
    UserManager<User> userManager,
    IHttpContextAccessor httpContextAccessor,
    IEmailConfirmationService emailConfirmationService)
    : IRequestHandler<ConfirmChangeEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ConfirmChangeEmailCommand request, CancellationToken cancellationToken)
    {
        var userIdClaim = httpContextAccessor.HttpContext!.User
               .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        int? userId = null;

        if (int.TryParse(userIdClaim, out var parsedId))
        {
            userId = parsedId;
        }
        var user = await userManager.FindByIdAsync(userId.ToString()!);
        if (user == null)
            return ErrorCode.UserNotFound;

        return await emailConfirmationService.ConfirmChangeEmail(user, request.Email, request.VerificationCode);
    }
}
