using System.Linq.Expressions;
using Music.Core.Entities;
using Music.Core.Parameters;
using Music.Core.Utilities;

namespace Music.Core.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<PagedList<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm, bool tracked = false);
    }
}
