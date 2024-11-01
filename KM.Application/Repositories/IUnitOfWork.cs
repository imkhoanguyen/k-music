﻿namespace KM.Application.Repositories
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        ISingerRepository Singer { get; }
        ISongRepository Song { get; }
        ISongGenreRepository SongGenre { get; }
        ISongSingerRepository SongSinger { get; }
        Task<bool> CompleteAsync();
    }
}
