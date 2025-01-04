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
            var query = tracked
                ? _context.Comments.AsQueryable()
                : _context.Comments.AsNoTracking().AsQueryable();

            query = query.Include(c => c.AppUser)
                         .Include(c => c.Replies)
                         .ThenInclude(reply => reply.AppUser);

            if (expression != null)
            {
                query = query.Where(expression);
            }

            // Lấy bình luận gốc (ParentComment == null)
            var parentCommentsQuery = query.Where(c => c.ParentComment == null);

            // Sắp xếp bình luận gốc
            if (!prm.OrderBy.IsNullOrEmpty())
            {
                parentCommentsQuery = prm.OrderBy switch
                {
                    "id" => parentCommentsQuery.OrderBy(r => r.Id),
                    "id_desc" => parentCommentsQuery.OrderByDescending(r => r.Id),
                    _ => parentCommentsQuery.OrderByDescending(r => r.Id),
                };
            }

            // Phân trang cho các bình luận gốc
            var pagedParentComments = await parentCommentsQuery.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);

            // Tải replies cho mỗi bình luận gốc
            foreach (var parentComment in pagedParentComments)
            {
                parentComment.Replies = await query
                    .Where(c => c.ParentCommentId == parentComment.Id)
                    .ToListAsync();
            }

            return pagedParentComments;
        }


        public override async Task<Comment?> GetAsync(Expression<Func<Comment, bool>> expression, bool tracked = false)
        {
            var query = tracked ? _context.Comments.AsQueryable() : _context.Comments.AsNoTracking().AsQueryable();

            query = query.Include(c => c.AppUser).Include(c => c.ParentComment).Include(c => c.Replies)
            .ThenInclude(reply => reply.AppUser);

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
