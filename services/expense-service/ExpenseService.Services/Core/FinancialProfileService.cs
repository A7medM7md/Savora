using ExpenseService.Application.Abstractions.Repositories;
using ExpenseService.Application.Abstractions.Services;
using ExpenseService.Application.Features.Commands.FinancialProfiles;
using ExpenseService.Domain.Entities.Core;

namespace ExpenseService.Services.Core
{
    public class FinancialProfileService(IGenericRepositoryAsync<UserFinancialProfile> repo) : IFinancialProfileService
    {
        public async Task<string> CreateFinancialProfileAsync(CreateFinancialProfileCommand command)
        {
            var financialProfile = new UserFinancialProfile
            {
                UserId = command.UserId,
                MonthlySalary = command.MonthlySalary,
                SalaryDay = command.SalaryDay,
                CurrentBalance = command.CurrentBalance,
                CreatedAt = DateTime.UtcNow
            };

            await repo.AddAsync(financialProfile);

            return "Successfully created financial profile.";
        }
    }
}
