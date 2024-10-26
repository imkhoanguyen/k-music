namespace KM.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public required string VipPlanName { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public required string Username { get; set; }
    }
}
