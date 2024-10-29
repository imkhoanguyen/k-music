namespace KM.Application.Repositories
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        ISingerRepository Singer { get; }

        Task<bool> CompleteAsync();
    }
}
