using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IApiService<T> {
        public Task<List<T>> GetAllAsync(string Uri);
        public Task<T> GetByIdAsync(string Uri);
        public Task CreateAsync(object item, string Uri);
        public Task UpdateAsync(object item, string Uri);
        public Task DeleteAsync(string Uri);
    }
}
