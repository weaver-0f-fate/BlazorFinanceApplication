using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IApiService<T> {
        public Task<List<T>> GetCollectionByUriAsync(string Uri);
        public Task<T> GetItemByUriAsync(string Uri);
        public Task CreateAsync(object item, string Uri);
        public Task UpdateAsync(object item, string Uri);
        public Task DeleteAsync(string Uri);
    }
}
