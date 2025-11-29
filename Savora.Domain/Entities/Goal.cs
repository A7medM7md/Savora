namespace Savora.Domain.Entities
{
    public class Goal : BaseEntitiy
    {
        public string Title { get; set; }

        // The target amount for the goal
        public decimal MoneyTarget { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
