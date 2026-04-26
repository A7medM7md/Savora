using ExpenseService.Api.Bases;
using ExpenseService.Application.Features.Commands.FinancialProfiles;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Api.Controllers
{
    public class FinancialProfilesController : AppControllerBase
    {
        [HttpPost(Router.UserFinancialProfileRouting.Create)]
        public async Task<IActionResult> CreateFinancialProfile([FromBody] CreateFinancialProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
