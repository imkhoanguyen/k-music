using Music.Application.DTOs.Comments;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;
using System.Linq.Expressions;

namespace Music.Application.Service.Abstract
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
