using ExpenseService.Domain.Entities.Core;
using ExpenseService.Infrastructure.Persistence.Contexts;

namespace AuthService.Infrastructure.DataSeeding
{
    public static class ExpenseCategoriesSeeder
    {
        public static async Task SeedAsync(SavoraExpenseContext db)
        {
            if (!db.ExpenseCategories.Any())
            {
                var expenseCategories = new List<ExpenseCategory>()
                    {
                        new ExpenseCategory { Id = 1, Name = "Food", Icon = "food_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 2, Name = "Transport", Icon = "transport_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 3, Name = "Bills", Icon = "bills_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 4, Name = "Shopping", Icon = "shopping_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 5, Name = "Entertainment", Icon = "entertainment_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 6, Name = "Health", Icon = "health_icon.png", IsSystem = true },
                        new ExpenseCategory { Id = 7, Name = "Education", Icon = "education_icon.png", IsSystem = true }
                    };

                await db.Set<ExpenseCategory>().AddRangeAsync(expenseCategories);
                await db.SaveChangesAsync();
            }
        }
    }
}