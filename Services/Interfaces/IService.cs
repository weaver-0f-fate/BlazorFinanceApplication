using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IService<T> {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(Guid id);
        public Task CreateAsync(T item);
        public Task DeleteAsync(Guid id);
    }
}
