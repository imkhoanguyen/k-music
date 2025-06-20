namespace Music.Core.Repositories
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        ISingerRepository Singer { get; }
        ISongRepository Song { get; }
        ISongGenreRepository SongGenre { get; }
        ISongSingerRepository SongSinger { get; }
        IPlaylistRepository Playlist { get; }
        IPlaylistSongRepository PlaylistSong { get; }
        IPlanRepository VipPackage { get; }
        ITransactionRepository UserVipSubscription { get; }
        ILikeSongRepository LikeSong { get; }
        ILikePlaylistRepository LikePlaylist { get; }
        ILikeSingerRepository LikeSinger { get; }
        ICommentRepository Comment { get; }
        Task<bool> CompleteAsync();

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        void Dispose();
    }
}
