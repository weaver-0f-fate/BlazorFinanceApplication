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
            //var operationTypes = await apiService.GetAllAsync();

            var operations = new List<Operation>();

            using (var response = await httpClient.GetAsync($"{Resources.ApiUrl}Operations")) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                operations = JsonConvert.DeserializeObject<List<Operation>>(apiResponse);
            }

            //cacheService.UpdateCacheValues(operationTypes);
            return operations;
        }

        public async Task<IEnumerable<Operation>> GetAllAtDateAsync(DateTime date) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Operation>> GetAllAtPeriodAsync(DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }

        public async Task<Operation> GetAsync(Guid id) {
            Operation operation;

            using (var response = await httpClient.GetAsync($"{Resources.ApiUrl}Operations/" + id)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                operation = JsonConvert.DeserializeObject<Operation>(apiResponse);
            }

            //cacheService.UpdateCacheValues(operationTypes);
            return operation;
        }

        public async Task CreateAsync(OperationCreateDTO operation) {
            StringContent content = new StringContent(JsonConvert.SerializeObject(operation), Encoding.UTF8, "application/json");
            Operation receivedOperation;
            using (var response = await httpClient.PostAsync($"{Resources.ApiUrl}Operations", content)) {
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

        public async Task UpdateAsync(Operation operation) {
            await Task.Delay(1);
            //TODO
        }

        public async Task DeleteAsync(Guid id) {
            using (var response = await httpClient.DeleteAsync($"{Resources.ApiUrl}Operations/" + id)) {
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode is HttpStatusCode.NoContent) {
                    //TODO delete from cache
                }
                else {
                    //TODO report exception
                }
            }
        }

        public Task CreateAsync(Operation item) {
            throw new NotImplementedException();
        }
    }
}
