using ExpenseService.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseService.Infrastructure.Persistence.Configurations
{
    public class ExpenseConfigurations : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            throw new NotImplementedException();
        }
    }
}
