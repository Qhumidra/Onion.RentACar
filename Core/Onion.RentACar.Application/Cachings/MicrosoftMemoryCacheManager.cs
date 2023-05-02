using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;

namespace Onion.RentACar.Application.Caching
{
    public class MicrosoftMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public MicrosoftMemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add(string key, object value, int duration)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public object? Get(string key)
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
