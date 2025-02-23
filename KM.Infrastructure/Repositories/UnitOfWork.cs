﻿using KM.Application.Repositories;
using KM.Infrastructure.DataAccess;

namespace KM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicContext _context;
        public IGenreRepository Genre { get; private set; }

        public ISingerRepository Singer { get; private set; }

        public ISongRepository Song { get; private set; }

        public ISongGenreRepository SongGenre { get; private set; }

        public ISongSingerRepository SongSinger { get; private set; }

        public IPlaylistRepository Playlist { get; private set; }

        public IPlaylistSongRepository PlaylistSong { get; private set; }

        public IVipPackageRepository VipPackage { get; private set; }

        public IUserVipSubscriptionRepository UserVipSubscription { get; private set; }

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
            VipPackage = new VipPackageRepository(_context);
            UserVipSubscription = new UserVipSubscriptionRepository(_context);
            LikeSong = new LikeSongRepository(_context);
            LikeSinger = new LikeSingerRepository(_context);
            LikePlaylist = new LikePlaylistRepository(_context);
            Comment = new CommentRepository(_context);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
