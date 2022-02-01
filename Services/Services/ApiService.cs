using Newtonsoft.Json;
using Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services {
    public class ApiService<T> : IApiService<T> {
        HttpClient httpClient;

        public ApiService(){
            httpClient = new HttpClient();
        }

        public async Task<List<T>> GetCollectionByUriAsync(string uri) {
            using var response = await httpClient.GetAsync(uri); 
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(apiResponse);
        }

        public async Task<T> GetItemByUriAsync(string uri) {
            using var response = await httpClient.GetAsync(uri); 
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(apiResponse);
        }

        public async Task CreateAsync(object item, string uri) {
            using var response = await httpClient.PostAsync(uri, GetContent(item)); 
            string apiResponse = await response.Content.ReadAsStringAsync();
            var receivedOperation = JsonConvert.DeserializeObject<T>(apiResponse);
        }

        public async Task UpdateAsync(object item, string uri) {
            using var response = await httpClient.PutAsync(uri, GetContent(item)); 
            string apiResponse = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteAsync(string uri) {
            using var response = await httpClient.DeleteAsync(uri);
            string apiResponse = await response.Content.ReadAsStringAsync();
        }

        private StringContent GetContent(object item) {
            return new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
        }
    }
}
