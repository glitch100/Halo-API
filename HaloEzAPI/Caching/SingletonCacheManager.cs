namespace HaloEzAPI.Caching
{
    public static class SingletonCacheManager
    {
        private static readonly CacheManager _instance = new CacheManager();

        static SingletonCacheManager()
        {
        }

        public static CacheManager Instance
        {
            get { return _instance; }
        }
    }
}