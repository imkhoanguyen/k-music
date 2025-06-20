namespace Music.Core.DTOs.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationDay { get; set; }
        public required string Description { get; set; }
        public required string UserName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
