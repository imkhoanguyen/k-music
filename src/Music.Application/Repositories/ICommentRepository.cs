using System.Linq.Expressions;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;

namespace KM.Application.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<PagedList<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm, bool tracked = false);
    }
}
