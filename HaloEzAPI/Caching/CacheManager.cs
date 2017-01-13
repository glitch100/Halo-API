using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Caching
{
    public class CacheManager: IApiCacheManager
    {
        private readonly object _lockObject = new object();
        private MemoryCache _cache;
        private readonly IList<string> _cacheKeysList; 
        public CacheManager()
        {
            _cache = MemoryCache.Default;
            _cacheKeysList = new List<string>();
        }

        public void Add<T>(T obj, string key, int expiryHours) where T : class 
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

        public T Get<T>(string key) where T: class 
        {
            var cachedItem = _cache.Get(key.ToLower());
            if (cachedItem != null)
            {
                return cachedItem as T;
            }

            return default(T);
        }

        public bool Contains(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            return _cache.Get(key.ToLower()) != null;
        }

        public void Remove(string key)
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

        public void RemoveAll()
        {
            foreach (var key in _cacheKeysList)
            {
                Remove(key);
            }
        }
    }
}
