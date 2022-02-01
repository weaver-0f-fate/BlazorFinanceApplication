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

        public async Task<OperationType> GetByIdAsync(Guid id) {
            var uri = $"{Resources.ApiOperationTypeUri}{id}";
            return await apiService.GetItemByUriAsync(uri);
        }

        public async Task CreateAsync(object operationType) {
            await apiService.CreateAsync(operationType, Resources.ApiOperationTypeUri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationTypeUri}{id}";
            await apiService.DeleteAsync(uri);
        }
    }
}
