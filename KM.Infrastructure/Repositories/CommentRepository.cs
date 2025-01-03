using System.Linq.Expressions;
using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KM.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly MusicContext _context;
        public CommentRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm, bool tracked = false)
        {
            var query = tracked ? _context.Comments.AsQueryable() : _context.Comments.AsNoTracking().AsQueryable();

            query = query.Include(c => c.AppUser).Include(c => c.ParentComment).Include(c => c.Replies)
            .ThenInclude(reply => reply.AppUser);

            query = query.Where(c => c.ParentComment == null);

            if(expression != null)
            {
                query = query.Where(expression);
            }
            

            if (!prm.OrderBy.IsNullOrEmpty())
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(r => r.Id),
                    "id_desc" => query.OrderByDescending(r => r.Id),
                    _ => query.OrderByDescending(r => r.Id),
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }
    }
}
