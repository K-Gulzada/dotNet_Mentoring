using Microsoft.Extensions.Caching.Memory;

namespace File_Cabinet.cache
{
    public class CacheDocument<T>
    {
        private const int SLIDING_EXPIRATION_TIME = 2;
        private const int ABSOLUTE_EXPIRATION_TIME = 10;
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 1024
        });

        public T GetOrCreate(object key, Func<T> createItem)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                 .SetSize(1)
                    .SetPriority(CacheItemPriority.High)
                    .SetSlidingExpiration(TimeSpan.FromSeconds(SLIDING_EXPIRATION_TIME))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(ABSOLUTE_EXPIRATION_TIME));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }              
    }
}
