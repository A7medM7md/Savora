using Microsoft.AspNetCore.Mvc;
using Savora.Api.Bases;
using Savora.Application.Features.Passwords.Commands.ChangePassword;
using Savora.Application.Features.Passwords.Commands.ResetPassword;
using Savora.Application.Features.Passwords.Commands.VerifyOTP;



namespace Savora.Api.Controllers
{
    public class PasswordController : AppControllerBase
    {
        [HttpPatch("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("SendResetPasswordOtp")]
        public async Task<IActionResult> SendResetPasswordOtp([FromBody] SendResetPasswordOTP command)
        {
            var result = await Mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] verifyOTPCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPatch("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
