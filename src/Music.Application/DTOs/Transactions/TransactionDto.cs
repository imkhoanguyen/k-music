namespace Music.Application.DTOs.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationDay { get; set; }
        public required string Description { get; set; }
        public required string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
