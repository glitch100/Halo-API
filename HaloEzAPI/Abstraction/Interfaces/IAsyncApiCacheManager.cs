using System.Threading.Tasks;

namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IAsyncApiCacheManager
    {
        Task Add<T>(T obj, string key, int expiryHours) where T : class;
        Task<T> Get<T>(string key) where T : class;
        Task<bool> Contains(string key);
        Task  Remove(string key);
        Task Bust();
    }
}