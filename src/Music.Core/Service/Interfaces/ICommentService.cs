using Music.Core.DTOs.Comments;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;
using System.Linq.Expressions;

namespace Music.Core.Service.Interfaces
{
    public interface ICommentService
    {
        Task<PagedList<CommentDto>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm);
        Task<CommentDto> AddAsync(CommentCreateDto dto);
        Task<CommentDto> UpdateAsync(CommentUpdateDto dto);
        Task<CommentDto> AddReplyAsync(ReplyCreateDto dto);
        Task RemoveAsync(Expression<Func<Comment, bool>> expression);
        Task<CommentDto> GetAsync(Expression<Func<Comment, bool>> expression);
    }
}
