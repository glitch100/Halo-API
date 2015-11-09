using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace HaloEzAPI.Caching
{
    public static class CacheManager
    {
        private static readonly object _lockObject = new object();
        private static MemoryCache _cache;
        private static readonly IList<string> _cacheKeysList; 
        static CacheManager()
        {
            _cache = MemoryCache.Default;
            _cacheKeysList = new List<string>();
        }

        public static void Add<T>(T obj, string key, int expiryHours) where T : class 
        {
            if (!string.IsNullOrEmpty(key) && !Contains(key))
            {
                lock (_lockObject)
                {
                    if (!Contains(key))
                    {
                        _cacheKeysList.Add(key);
                        _cache.Add(key.ToLower(),obj,new DateTimeOffset(DateTime.UtcNow.AddHours(expiryHours)));
                    }
                }
            }
        }

        public static T Get<T>(string key) where T: class 
        {
            var cachedItem = _cache.Get(key.ToLower());
            if (cachedItem != null)
            {
                return cachedItem as T;
            }

            return default(T);
        }

        public static bool Contains(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            return _cache.Get(key.ToLower()) != null;
        }

        public static void Remove(string key)
        {
            if (Contains(key))
            {
                lock (_lockObject)
                {
                    if (Contains(key))
                    {
                        _cache.Remove(key.ToLower());
                    }
                }
            }
        }

        public static void RemoveAll()
        {
            foreach (var key in _cacheKeysList)
            {
                Remove(key);
            }
        }
    }
}
