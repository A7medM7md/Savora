using MediatR;
using Microsoft.Extensions.Localization;
using AuthService.Application.Abstractions.Services;
using AuthService.Application.Bases;
using AuthService.Application.Features.Authentication.Queries.Models;
using AuthService.Application.Resources;
using AuthService.Domain.Commons;
using System.Net;

namespace AuthService.Application.Features.Authentication.Commands.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                                    IRequestHandler<VerifyResetPasswordCodeQuery, Response<bool>>
    {
        #region Fields

        private readonly IPasswordResetService _passwordResetService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion


        #region Constructors

        public AuthenticationQueryHandler(IPasswordResetService passwordResetService,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _localizer = localizer;
            _passwordResetService = passwordResetService;
        }

        #endregion


        #region Handle Functions

        public async Task<Response<bool>> Handle(VerifyResetPasswordCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _passwordResetService.VerifyResetCodeAsync(request.Email, request.ResetCode);

            return result.StatusCode switch
            {
                HttpStatusCode.OK => Success(result.Data, result.Message),
                HttpStatusCode.BadRequest => BadRequest<bool>(result.Message),
                HttpStatusCode.NotFound => NotFound<bool>(_localizer[SharedResourcesKeys.UserIsNotFound]),
                _ => InternalServerError<bool>(result.Message)
            };
        }


        #endregion


    }
}
