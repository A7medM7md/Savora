using AuthService.Application.Abstractions.Services;
using AuthService.Application.Bases;
using AuthService.Application.Features.Emails.Commands.Models;
using AuthService.Application.Resources;
using AuthService.Domain.Commons;
using MediatR;
using Microsoft.Extensions.Localization;

namespace AuthService.Application.Features.Emails.Commands.Handlers
{
    public class EmailCommandHandler : ResponseHandler,
                                            IRequestHandler<SendEmailCommand, Response<string>>
    {
        private readonly IEmailService _emailService;

        public EmailCommandHandler(IEmailService emailService,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendEmailAsync(request, cancellationToken);

            if (!response.Succeeded)
            {
                return Response<string>.Fail(
                    message: response.Message,
                    statusCode: response.StatusCode,
                    errors: response.Errors
                );
            }

            return Success(response.Message);
        }
    }
}
