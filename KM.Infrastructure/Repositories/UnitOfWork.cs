﻿using KM.Application.Repositories;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicContext _context;
        public IGenreRepository Genre { get; private set; }

        public ISingerRepository Singer { get; private set; }

        public UnitOfWork(MusicContext context)
        {
            _context = context;
            Genre = new GenreRepository(_context);
            Singer = new SingerRepository(_context);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
