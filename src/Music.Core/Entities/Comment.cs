using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Music.Core.Entities.Abstracts;
using Music.Core.Enum;

namespace Music.Core.Entities
{
    public class Comment : EntityAuditBase<int>
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        public int RelatedId { get; set; } // id song, playlist, singer
        public CommentType RelatedType { get; set; }
        public int? ParentCommentId { get; set; }
        //nav
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public Comment? ParentComment { get; set; } // Comment cha nếu là reply
        public List<Comment> Replies { get; set; } = []; // Các reply cho comment này
    }
}
