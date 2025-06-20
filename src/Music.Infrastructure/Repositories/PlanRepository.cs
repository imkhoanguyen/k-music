using System.Linq.Expressions;
using Music.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Music.Core.Entities;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        private readonly MusicContext _context;
        public PlanRepository(MusicContext context) : base(context)
        {
            _context = context;
        }
    }
}
