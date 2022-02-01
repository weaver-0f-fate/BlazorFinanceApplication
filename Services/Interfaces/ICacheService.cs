using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface ICacheService<T> {
        public Task<T> GetOrCreateAsync(object key, Func<Task<T>> createItem);
        public void Create(object key, T item);
        public void DeleteIfExists(object key);
        public void Update(object key, T item);
    }
}
