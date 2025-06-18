using KM.Domain.Enum;

namespace KM.Application.Parameters
{
    public class CommentParams : BaseParams
    {
        public required CommentType RelatedType { get; set; }
        public required int RelatedId { get; set; }
    }
}
