using Microsoft.AspNetCore.Mvc;
using Savora.Api.Bases;

namespace Savora.Api.Controllers
{
    public class ExpensesController : AppControllerBase
    {
        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(new { Message = "Expenses retrieved successfully." });
        }
    }
}
