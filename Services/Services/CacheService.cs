using Core.Models;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class CacheService<T> : ICacheService<T> where T : AbstractModel{
        private MemoryCache cache;

        public CacheService() {
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<T> GetOrCreateAsync(Guid key, Func<Guid, Task<T>> createItem) {
            T cacheEntry;

            if (!cache.TryGetValue(key, out cacheEntry)) {
                cacheEntry = await createItem(key);
                AddToCache(cacheEntry);
            }
            return cacheEntry;
        }

        private void AddToCache(T cacheEntry) {
            const int SecondsToExpiration = 30;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(SecondsToExpiration));

            cache.Set(cacheEntry.Id, cacheEntry, cacheEntryOptions);
        }

        public void Delete(Guid key) {
            if (cache.TryGetValue(key, out var cacheEntry)) {
                cache.Remove(cacheEntry);
            }
        }
        public void Update(T item) {
            Delete(item.Id);
            AddToCache(item);
        }

        public void UpdateCacheValues(IEnumerable<T> values) {
            foreach(var item in values) {
                Update(item);
            }
        }
    }
}
