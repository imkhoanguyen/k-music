namespace Music.Application.DTOs.Comments
{
    public class ReplyCreateDto
    {
        public required string Content { get; set; }
        public int ParentCommentId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int RelatedId { get; set; }
        public required string RelatedType { get; set; }
    }
}
