namespace KM.Domain.Entities
{
    public class VipPackage : BaseEntity
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSell { get; set; }
        public int DurationDay { get; set; }
        public required string Description { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
