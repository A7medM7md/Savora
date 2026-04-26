using ExpenseService.Application.Features.Commands.Expenses;

namespace ExpenseService.Application.Abstractions.Services
{
    public interface IExpenseService
    {
        public Task<string> AddExpenseAsync(AddExpenseCommand command);
    }
}
