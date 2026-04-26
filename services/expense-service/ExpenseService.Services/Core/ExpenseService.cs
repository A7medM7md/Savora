using ExpenseService.Application.Abstractions.Repositories;
using ExpenseService.Application.Abstractions.Services;
using ExpenseService.Application.Features.Commands.Expenses;
using ExpenseService.Domain.Entities.Core;

namespace ExpenseService.Services.Core
{
    public class ExpenseService(IGenericRepositoryAsync<Expense> repo) : IExpenseService
    {
        public async Task<string> AddExpenseAsync(AddExpenseCommand command)
        {
            var expense = new Expense
            {
                Title = command.Title,
                Amount = command.Amount,
                Notes = command.Notes,
                Priority = command.Priority,
            };

            await repo.AddAsync(expense);

            return "Success";
        }
    }
}
