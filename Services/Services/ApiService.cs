using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services {
    public class ApiService<T> : IApiService<T> {
        HttpClient httpClient;

        public ApiService(){
            httpClient = new HttpClient();
        }

        public async Task<List<T>> GetAllAsync(string Uri) {
            using (var response = await httpClient.GetAsync(Uri)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
        }


        public Task CreateAsync(T item, string Uri) {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string Uri) {
            using (var response = await httpClient.DeleteAsync(Uri)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
            };
        }

        public async Task<T> GetByIdAsync(Guid id, string Uri) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item, string Uri) {
            throw new NotImplementedException();
        }
    }
}
