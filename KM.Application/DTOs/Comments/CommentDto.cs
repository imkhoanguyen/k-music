using KM.Domain.Enum;

namespace KM.Application.DTOs.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public int? ParentCommentId { get; set; }
        public UserCommentDto? UserComment { get; set; }
        public List<CommentDto> Replies { get; set; } = [];
    }
}
