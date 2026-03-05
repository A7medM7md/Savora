using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthService.Api.Bases;
using AuthService.Application.Features.Emails.Commands.Models;

namespace AuthService.Api.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.EmailRouting.Send)]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
