namespace KM.Application.DTOs.Comments
{
    public class CommentCreateDto
    {
        public required string Content { get; set; }
        public int RelatedId { get; set; }
        public required string RelatedType { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
