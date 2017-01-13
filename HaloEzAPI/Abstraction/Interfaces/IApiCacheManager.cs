namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IApiCacheManager
    {
        void Add<T>(T obj, string key, int expiryHours) where T : class;
        T Get<T>(string key) where T : class;
        bool Contains(string key);
        void Remove(string key);
        void RemoveAll();
    }
}