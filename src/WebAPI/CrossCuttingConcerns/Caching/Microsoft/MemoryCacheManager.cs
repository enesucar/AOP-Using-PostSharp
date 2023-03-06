using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Set(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
