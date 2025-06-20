using Music.Application.DTOs.Comments;
using Music.Domain.Entities;

namespace Music.Application.Mappers
{
    public class CommentMapper
    {
        public static CommentDto EntityToCommentDto(Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,
                Content = entity.Content,
                Created = entity.Created,
                Updated = entity.Updated,
                ParentCommentId = entity.ParentCommentId,
                UserComment = new UserCommentDto { UserName = entity.AppUser.UserName, FullName = entity.AppUser.FullName, ImgUrl = entity.AppUser.ImgUrl },
                Replies = entity.Replies.Select(EntityToCommentDto).ToList(),
            };
        }
    }
}
