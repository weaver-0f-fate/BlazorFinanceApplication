using Core.Models;
using Services.Interfaces;
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

        public async Task<IEnumerable<OperationType>> GetAllAsync() {
            var operationTypes = await apiService.GetAllAsync();
            cacheService.UpdateCacheValues(operationTypes);
            return operationTypes;
        }
        public async Task<OperationType> GetAsync(Guid id) {
            return await cacheService.GetOrCreateAsync(id, x => apiService.GetByIdAsync(x));
        }
        public async Task CreateAsync(OperationType item) {
            await Task.Delay(1);
            //TODO
            /*
             * 1. Call Api to 
             * 
             * 
             */
        }
        public async Task UpdateAsync(OperationType item) {
            await Task.Delay(1);
            //TODO 
        }
        public async Task DeleteAsync(Guid id) {
            await Task.Delay(1);
            //TODO 
        }
    }
}
