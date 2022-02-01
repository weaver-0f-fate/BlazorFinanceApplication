using Core.Models;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : IOperationTypesService {
        private ICacheService<OperationType> cacheService;
        private IApiService<OperationType> apiService;

        public OperationTypesService(ICacheService<OperationType> cacheService, IApiService<OperationType> apiService) {
            this.cacheService = cacheService;
            this.apiService = apiService;
        }

        public async Task<List<OperationType>> GetAllAsync() {
            return await apiService.GetCollectionByUriAsync(Resources.ApiOperationTypeUri);
        }

        public async Task CreateAsync(OperationType operationType) {
            var response = await apiService.CreateAsync(operationType, Resources.ApiOperationTypeUri);
            if(response.StatusCode is System.Net.HttpStatusCode.Created) {
                cacheService.Create(operationType.Id, operationType);
            }
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationTypeUri}{id}";
            var response = await apiService.DeleteAsync(uri);
            if (response.StatusCode is System.Net.HttpStatusCode.NoContent) {
                cacheService.DeleteIfExists(id);
            }
        }
    }
}
