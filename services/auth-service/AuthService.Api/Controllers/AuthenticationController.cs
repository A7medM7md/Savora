using AuthService.Api.Bases;
using AuthService.Application.Features.Authentication.Commands.Models;
using AuthService.Application.Features.Authentication.Queries.Models;
using AuthService.Application.Features.OAuth.Commands.Models;
using AuthService.Application.Features.Users.Commands.Models;
using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.JWT;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{

    public class AuthenticationController : AppControllerBase
    {

        [HttpPost(Router.AuthenticationRouting.SignInWithGoogle)]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleSignInCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost(Router.AuthenticationRouting.SignIn)]
        public async Task<ActionResult<Response<SignInResponse>>> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.AuthenticationRouting.Register)]
        public async Task<ActionResult<Response<string>>> Register([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        public async Task<ActionResult<Response<SignInResponse>>> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        //[SwaggerOperation(Summary = "Validate JWT Token", OperationId = "ValidateToken", Description = "This endpoint validates a JWT token"),]
        [ProducesResponseType(typeof(TokenValidationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenValidationResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(TokenValidationResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(TokenValidationResponse), StatusCodes.Status404NotFound)]
        [HttpPost(Router.AuthenticationRouting.ValidateToken)]
        public async Task<ActionResult<Response<TokenValidationResponse>>> ValidateToken([FromBody] ValidateTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(Router.AuthenticationRouting.ConfirmEmail)] // GET: baseUrl/api/v1/authentication/confirm-email
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost(Router.AuthenticationRouting.SendResetPasswordCode)]
        public async Task<IActionResult> SendResetPasswordCode([FromBody] SendResetPasswordCodeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost(Router.AuthenticationRouting.VerifyResetPasswordCode)]
        public async Task<IActionResult> VerifyResetPasswordCode([FromBody] VerifyResetPasswordCodeQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }


        [HttpPost(Router.AuthenticationRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
