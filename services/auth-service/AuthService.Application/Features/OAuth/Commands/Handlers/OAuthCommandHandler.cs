using AuthService.Application.Abstractions.Services;
using AuthService.Application.Bases;
using AuthService.Application.Features.OAuth.Commands.Models;
using AuthService.Application.Resources;
using AuthService.Domain.Commons;
using AuthService.Domain.Entities.Identity;
using AuthService.Domain.Helpers.JWT;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Net;

namespace AuthService.Application.Features.OAuth.Commands.Handlers
{
    public class OAuthCommandHandler : ResponseHandler
            , IRequestHandler<GoogleSignInCommand, Response<SignInResponse>>
    {
        private readonly IGoogleTokenValidator _googleValidator;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public OAuthCommandHandler(
            IGoogleTokenValidator googleValidator,
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _googleValidator = googleValidator;
            _userManager = userManager;
            _tokenService = tokenService;
            _localizer = localizer;
        }

        public async Task<Response<SignInResponse>> Handle(
            GoogleSignInCommand request,
            CancellationToken cancellationToken)
        {
            // Validate Google token
            GoogleJsonWebSignature.Payload payload;

            try
            {
                payload = await _googleValidator.ValidateAsync(request.IdToken);
            }
            catch
            {
                return Response<SignInResponse>.Fail(
                _localizer[SharedResourcesKeys.InvalidExternalLoginWithGoogle],
                    HttpStatusCode.Unauthorized
                );
            }

            // Find user by Google Provider

            /// Using Custom Fields in AppUser [Not Recommended, Development]
            ///var user = await _userManager.Users.FirstOrDefaultAsync(u =>
            ///    u.Provider == "Google" &&
            ///    u.ProviderId == payload.Subject,
            ///    cancellationToken);

            // Using UserLogins Table (Recommended, Production)
            var user = await _userManager.FindByLoginAsync(
                "Google",
                payload.Subject
            );

            // Create user if first login
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    user = new AppUser
                    {
                        UserName = payload.Email,
                        Email = payload.Email,
                        FullName = payload.Name,
                        EmailConfirmed = true // Google already verified
                        //Provider = "Google",
                        //ProviderId = payload.Subject,
                    };

                    var createResult = await _userManager.CreateAsync(user);

                    if (!createResult.Succeeded)
                        return InternalServerError<SignInResponse>(_localizer[SharedResourcesKeys.FaildToAddUser], createResult.Errors.Select(e => e.Description).ToList());
                }

                // Attach Google login to user
                var addLoginResult = await _userManager.AddLoginAsync(
                    user,
                    new UserLoginInfo(
                        "Google",
                        payload.Subject,
                        "Google"
                    )
                );

                if (!addLoginResult.Succeeded)
                    return BadRequest<SignInResponse>(_localizer[SharedResourcesKeys.InvalidExternalLoginWithGoogle], addLoginResult.Errors.Select(e => e.Description).ToList());
            }

            // Generate tokens
            var tokenResponse = await _tokenService.GenerateJwtTokenAsync(user);

            return Success(tokenResponse);
        }
    }
}