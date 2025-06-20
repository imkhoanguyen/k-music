namespace Music.Application.Parameters
{
    public class TransactionParams : BaseParams
    {
        public override string OrderBy { get; set; } = "endDate_desc";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
