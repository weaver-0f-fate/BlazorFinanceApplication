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
            return await apiService.GetAllAsync(Resources.ApiOperationTypeUri);
        }

        public Task<OperationType> GetAsync(Guid id) {
            throw new NotImplementedException();
            //return await cacheService.GetOrCreateAsync(id, x => apiService.GetByIdAsync(x));
        }

        public async Task CreateAsync(OperationType operationType) {
            await apiService.CreateAsync(operationType, Resources.ApiOperationTypeUri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationTypeUri}{id}";
            await apiService.DeleteAsync(uri);
        }
    }
}
