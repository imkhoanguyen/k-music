using Microsoft.EntityFrameworkCore.Storage;
using Music.Core.Repositories;
using Music.Infrastructure.DataAccess;

namespace Music.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicContext _context;
        private IDbContextTransaction _dbContextTransaction;
        private bool _disposed;
        public IGenreRepository Genre { get; private set; }

        public ISingerRepository Singer { get; private set; }

        public ISongRepository Song { get; private set; }

        public ISongGenreRepository SongGenre { get; private set; }

        public ISongSingerRepository SongSinger { get; private set; }

        public IPlaylistRepository Playlist { get; private set; }

        public IPlaylistSongRepository PlaylistSong { get; private set; }

        public IPlanRepository VipPackage { get; private set; }

        public ITransactionRepository UserVipSubscription { get; private set; }

        public ILikeSongRepository LikeSong { get; private set; }

        public ILikePlaylistRepository LikePlaylist { get; private set; }

        public ILikeSingerRepository LikeSinger { get; private set; }

        public ICommentRepository Comment { get; private set; }

        public UnitOfWork(MusicContext context)
        {
            _context = context;
            Genre = new GenreRepository(_context);
            Singer = new SingerRepository(_context);
            Song = new SongRepository(_context);
            SongGenre = new SongGenreRepository(_context);
            SongSinger = new SongSingerRepository(_context);
            Playlist = new PlaylistRepository(_context);
            PlaylistSong = new PlaylistSongRepository(_context);
            VipPackage = new PlanRepository(_context);
            UserVipSubscription = new TransactionRepository(_context);
            LikeSong = new LikeSongRepository(_context);
            LikeSinger = new LikeSingerRepository(_context);
            LikePlaylist = new LikePlaylistRepository(_context);
            Comment = new CommentRepository(_context);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task BeginTransactionAsync()
        {
            _dbContextTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if(_dbContextTransaction != null)
                await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if(_dbContextTransaction != null)
                await _dbContextTransaction.RollbackAsync();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // equal: _dbContextTransaction?.Dispose();
                    if (_dbContextTransaction != null)
                        _dbContextTransaction.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
