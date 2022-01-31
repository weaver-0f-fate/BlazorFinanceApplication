using Core.Models;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : IOperationTypesService {
        private ICacheService<OperationType> cacheService;
        private IApiService<OperationType> apiService;
        private HttpClient httpClient;


        public OperationTypesService(ICacheService<OperationType> cacheService, IApiService<OperationType> apiService) {
            this.cacheService = cacheService;
            this.apiService = apiService;
            httpClient = new HttpClient();
        }

        public async Task<List<OperationType>> GetAllAsync() {
            //var operationTypes = await apiService.GetAllAsync();

            List<OperationType> operationTypes = new List<OperationType>();

            using (var response = await httpClient.GetAsync($"{Resources.ApiUrl}OperationTypes")) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                operationTypes = JsonConvert.DeserializeObject<List<OperationType>>(apiResponse);
            }

            //cacheService.UpdateCacheValues(operationTypes);
            return operationTypes;
        }

        public Task<OperationType> GetAsync(Guid id) {
            throw new NotImplementedException();
            //return await cacheService.GetOrCreateAsync(id, x => apiService.GetByIdAsync(x));
        }

        public async Task CreateAsync(OperationType item) {
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            OperationType receivedType;
            using (var response = await httpClient.PostAsync($"{Resources.ApiUrl}OperationTypes", content)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                receivedType = JsonConvert.DeserializeObject<OperationType>(apiResponse);

                if(response.StatusCode is HttpStatusCode.Created) {
                    //TODO add to cache?
                }
                else {
                    //TODO show exception to user.
                }
            }
        }

        public Task UpdateAsync(OperationType item) {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(Guid id) {
            using (var response = await httpClient.DeleteAsync($"{Resources.ApiUrl}OperationTypes/" + id)) {
                string apiResponse = await response.Content.ReadAsStringAsync();

                if(response.StatusCode is HttpStatusCode.NoContent) {
                    //TODO delete from cache
                }
            }
        }
    }
}
