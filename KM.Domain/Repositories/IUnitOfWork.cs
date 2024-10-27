namespace KM.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }

        Task<bool> CompleteAsync();
    }
}
