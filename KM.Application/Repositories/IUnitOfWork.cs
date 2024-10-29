namespace KM.Application.Repositories
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }

        Task<bool> CompleteAsync();
    }
}
