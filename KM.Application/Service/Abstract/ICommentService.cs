using KM.Application.DTOs.Comments;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using System.Linq.Expressions;

namespace KM.Application.Service.Abstract
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
