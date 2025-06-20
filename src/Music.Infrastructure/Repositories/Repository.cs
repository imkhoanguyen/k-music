﻿using Music.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MusicContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MusicContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _dbSet.AsQueryable() : _dbSet.AsNoTracking().AsQueryable();
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool tracked = false)
        {
            if (tracked)
            {
                return await _dbSet.FirstOrDefaultAsync(expression);
            }

            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
        }


        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }

}
