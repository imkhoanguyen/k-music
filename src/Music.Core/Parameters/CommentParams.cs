using Music.Core.Enum;

namespace Music.Core.Parameters
{
    public class CommentParams : BaseParams
    {
        public required CommentType RelatedType { get; set; }
        public required int RelatedId { get; set; }
    }
}
