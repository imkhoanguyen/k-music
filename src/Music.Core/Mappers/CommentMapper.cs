using Music.Core.DTOs.Comments;
using Music.Core.Entities;

namespace Music.Core.Mappers
{
    public class CommentMapper
    {
        public static CommentDto EntityToCommentDto(Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,
                Content = entity.Content,
                Created = (DateTimeOffset)entity.CreatedDate,
                Updated = (DateTimeOffset)entity.LastModifiedDate,
                ParentCommentId = entity.ParentCommentId,
                UserComment = new UserCommentDto { UserName = entity.AppUser.UserName, FullName = entity.AppUser.FullName, ImgUrl = entity.AppUser.ImgUrl },
                Replies = entity.Replies.Select(EntityToCommentDto).ToList(),
            };
        }
    }
}
