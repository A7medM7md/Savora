using ExpenseService.Application.Features.Commands.FinancialProfiles;

namespace ExpenseService.Application.Abstractions.Services
{
    public interface IFinancialProfileService
    {
        public Task<string> CreateFinancialProfileAsync(CreateFinancialProfileCommand command);
    }
}
