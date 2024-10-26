namespace KM.Domain.Entities
{
    public class VipPlan : BaseEntity
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSell { get; set; }
        public int Duration { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
