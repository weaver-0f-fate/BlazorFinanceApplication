using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IApiService<T> {
        public Task<List<T>> GetCollectionByUriAsync(string Uri);
        public Task<T> GetItemByUriAsync(string Uri);
        public Task<HttpResponseMessage> CreateAsync(object item, string Uri);
        public Task<HttpResponseMessage> UpdateAsync(object item, string Uri);
        public Task<HttpResponseMessage> DeleteAsync(string Uri);
    }
}
