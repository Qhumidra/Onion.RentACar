using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Tools.Caching
{
    public static class CacheTool
    {
        public static bool IsExist(string key, ICacheManager cache)
        {
            if (cache.IsAdd(key))
            {
                return true;
            }
            return false;
        }

        public static object? GetCache(string key, ICacheManager cache)
        {
            return cache.Get(key);
        }

        public static void AddCache(string key, object value, ICacheManager cache, int duration)
        {
            cache.Add(key, value, duration);
        }

        public static void RemoveCache(string key, ICacheManager cache)
        {
            if (cache.IsAdd(key))
            {
                cache.Remove(key);
                return;
            }
        }
    }
}

