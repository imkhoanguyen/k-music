using System.Linq.Expressions;
using Music.Application.Parameters;
using Music.Application.Utilities;
using Music.Domain.Entities;

namespace Music.Application.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<PagedList<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm, bool tracked = false);
    }
}
