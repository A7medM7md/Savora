using ExpenseService.Application.Abstractions.Services;
using ExpenseService.Application.Bases;
using ExpenseService.Application.Resources;
using ExpenseService.Domain.Commons;
using MediatR;
using Microsoft.Extensions.Localization;

namespace ExpenseService.Application.Features.Commands.FinancialProfiles
{
    public record CreateFinancialProfileCommand(int UserId, decimal MonthlySalary, int SalaryDay, decimal CurrentBalance) : IRequest<Response<string>>;

    public class CreateFinancialProfileCommandHandler(IFinancialProfileService financialProfileService, IStringLocalizer<SharedResources> localizer)
        : ResponseHandler(localizer), IRequestHandler<CreateFinancialProfileCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(CreateFinancialProfileCommand request, CancellationToken cancellationToken)
        {
            await financialProfileService.CreateFinancialProfileAsync(request);
            return Success("Financial profile created successfully");
        }
    }

}
