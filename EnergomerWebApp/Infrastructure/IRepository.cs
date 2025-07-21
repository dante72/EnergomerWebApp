using Microsoft.AspNetCore.SignalR;

namespace EnergomerWebApp.Infrastructure
{
    public interface IRepository<T>
    {
        Task<T> Get();
    }

}
