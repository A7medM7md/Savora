using Savora.Domain.Entities.Identity;
using Savora.Domain.Enums;

namespace Savora.Domain.Entities
{
    public class Income : BaseEntitiy
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public IncomeType Type { get; set; }

        // The amount in the currency it was received in
        public decimal OriginalAmount { get; set; }

        // The currency of the original amount (e.g., "JPY", "EUR")
        public string OriginalCurrency { get; set; }

        // The amount converted to the user's BaseCurrency
        public decimal BaseAmount { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
