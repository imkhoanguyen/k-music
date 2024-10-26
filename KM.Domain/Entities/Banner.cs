namespace KM.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public required string ImgUrl { get; set; }
        public string? PublicId { get; set; }
    }
}
