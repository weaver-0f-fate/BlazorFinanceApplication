using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class CacheService<T> : ICacheService<T> {
        private MemoryCache cache;

        public CacheService() {
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<T> GetOrCreateAsync(object key, Func<Task<T>> createItem) {
            T cacheEntry;

            if (!cache.TryGetValue(key, out cacheEntry)) {
                cacheEntry = await createItem();
                Create(key, cacheEntry);
            }
            return cacheEntry;
        }

        public void Create(object key, T item) {
            const int SecondsToExpiration = 300;
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(SecondsToExpiration));
            cache.Set(key, item, cacheEntryOptions);
        }
        public void Update(object key, T item) {
            //Delete(item.Id);
            Create(key, item);
        }

        public void DeleteIfExists(object key) {
            if (cache.TryGetValue(key, out var cacheEntry)) {
                cache.Remove(cacheEntry);
            }
        }
    }
}
