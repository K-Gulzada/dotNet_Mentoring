using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.cache
{
    public class CacheDocument<T>
    {
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
                    .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

      /*  public IEnumerable GetTypeOneDocuments()
        {
            var dn_number = "DN_111 Book";

            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(dn_number))
            {
                return (IEnumerable)cache.Get(dn_number);
            }
            else
            {
                var documents = SeedExtension.CreateDefaultDocument();

                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1),
                    Priority = CacheItemPriority.Default,
                };

                cache.Add(dn_number, documents, policy);

                return documents;
            }
        }
*/

       
    }
}
