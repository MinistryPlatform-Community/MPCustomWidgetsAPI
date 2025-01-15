using System.Runtime.Caching;

namespace Microservices.Providers
{
    public static class CacheProvider
    {
        private static ObjectCache cache = MemoryCache.Default;

        public static T GetItem<T>(string cacheItemName)
        {
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                return default(T);
            }
            return cachedObject;
        }

        public static T AddItem<T>(string cacheItemName, int cacheTimeOutMinutes, object cachedObject)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeOutMinutes);
            cache.Set(cacheItemName, cachedObject, policy);

            return (T)cachedObject;
        }

        public static bool CheckForCacheItem(string cacheItemName)
        {
            if (cache.Contains(cacheItemName))
            {
                return true;
            }
            return false;
        }

        public static bool ClearItem(string cacheItemName)
        {
            cache.Remove(cacheItemName);
            return true;
        }

        public static bool ClearCache()
        {
            foreach (var item in MemoryCache.Default)
            {
                ClearItem(item.Key);
            }
            return true;
        }
    }
}
