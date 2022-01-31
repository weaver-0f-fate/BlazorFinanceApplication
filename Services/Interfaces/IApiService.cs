using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IApiService<T> {
        public Task<List<T>> GetAllAsync(string Uri);
        public Task<T> GetByIdAsync(Guid id, string Uri);
        public Task CreateAsync(T item, string Uri);
        public Task UpdateAsync(T item, string Uri);
        public Task DeleteAsync(string Uri);
    }
}
