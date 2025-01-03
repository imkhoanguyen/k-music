using System.ComponentModel.DataAnnotations.Schema;
using KM.Domain.Enum;

namespace KM.Domain.Entities
{
    public class Comment : BaseEntity 
    {
        public required string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public int RelatedId { get; set; } // id song, playlist, singer
        public CommentType RelatedType { get; set; }
        public int? ParentCommentId { get; set; }
        //nav
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public Comment? ParentComment { get; set; } // Comment cha nếu là reply
        public List<Comment> Replies { get; set; } = []; // Các reply cho comment này
    }
}
