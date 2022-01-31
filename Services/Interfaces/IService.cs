using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IService<T> {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task CreateAsync(object item);
        public Task DeleteAsync(Guid id);
    }
}
