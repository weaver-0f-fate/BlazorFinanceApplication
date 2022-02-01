using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface ICacheService<T> {
        public Task<T> GetOrCreateAsync(Guid key, Func<Guid, Task<T>> createItem);
        public void Delete(Guid key);
        public void Update(T item);
        public void UpdateCacheValues(IEnumerable<T> values);
    }
}
