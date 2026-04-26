using ExpenseService.Application.Abstractions.Services;
using ExpenseService.Application.Bases;
using ExpenseService.Application.Resources;
using ExpenseService.Domain.Commons;
using ExpenseService.Domain.Helpers.Enums;
using MediatR;
using Microsoft.Extensions.Localization;

namespace ExpenseService.Application.Features.Commands.Expenses
{
    public record AddExpenseCommand(string Title, decimal Amount, ExpensePriority Priority, string Notes) : IRequest<Response<string>>;

    public class AddExpenseCommandHandler(IExpenseService expenseService, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer), IRequestHandler<AddExpenseCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            await expenseService.AddExpenseAsync(request);
            return Success("Expense added.");
        }
    }
}
