using Core.Models;
using Newtonsoft.Json;
using Services.DTO;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationsService : IOperationsService {
        private ICacheService<Operation> cacheService;
        private IApiService<Operation> apiService;
        private HttpClient httpClient;

        public OperationsService(ICacheService<Operation> cacheService, IApiService<Operation> apiService) {
            this.cacheService = cacheService;
            this.apiService = apiService;
            httpClient = new HttpClient();
        }

        public async Task<List<Operation>> GetAllAsync() {
            return await apiService.GetAllAsync(Resources.ApiOperationUri);
        }

        public async Task<Operation> GetAsync(Guid id) {
            Operation operation;

            using (var response = await httpClient.GetAsync($"{Resources.ApiOperationUri}{id}")) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                operation = JsonConvert.DeserializeObject<Operation>(apiResponse);
            }

            //cacheService.UpdateCacheValues(operationTypes);
            return operation;
        }

        public async Task CreateAsync(OperationCreateDTO operation) {
            StringContent content = new StringContent(JsonConvert.SerializeObject(operation), Encoding.UTF8, "application/json");
            Operation receivedOperation;
            using (var response = await httpClient.PostAsync(Resources.ApiOperationUri, content)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                receivedOperation = JsonConvert.DeserializeObject<Operation>(apiResponse);

                if (response.StatusCode is HttpStatusCode.Created) {
                    //TODO add to cache?
                }
                else {
                    //TODO show exception to user.
                }
            }
        }

        public async Task UpdateAsync(Guid id, OperationCreateDTO operationDTO) {
            var content = new StringContent(JsonConvert.SerializeObject(operationDTO), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PutAsync($"{Resources.ApiOperationUri}{id}", content)) {
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode is HttpStatusCode.NoContent) {
                    //TODO update in cache
                }
                else {
                    //TODO report exception
                }
            }
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            await apiService.DeleteAsync(uri);
        }

        public Task CreateAsync(Operation item) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Operation item) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Operation>> GetAllAtDateAsync(DateTime date) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Operation>> GetAllAtPeriodAsync(DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }
    }
}
