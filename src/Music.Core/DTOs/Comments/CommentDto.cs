namespace Music.Core.DTOs.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Updated { get; set; }
        public int? ParentCommentId { get; set; }
        public UserCommentDto? UserComment { get; set; }
        public List<CommentDto> Replies { get; set; } = [];
    }
}
