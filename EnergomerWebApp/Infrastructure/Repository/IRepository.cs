namespace EnergomerWebApp.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get();
    }

}
