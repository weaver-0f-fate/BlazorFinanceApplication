using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IApiService<T> {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task CreateAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(Guid id);
    }
}
