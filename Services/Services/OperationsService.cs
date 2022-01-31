using Core.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationsService : IOperationsService {
        private ICacheService<Operation> cacheService;
        private IApiService<Operation> apiService;

        public OperationsService(ICacheService<Operation> cacheService, IApiService<Operation> apiService) {
            this.cacheService = cacheService;
            this.apiService = apiService;
        }

        public async Task<List<Operation>> GetAllAsync() {
            return await apiService.GetAllAsync(Resources.ApiOperationUri);
        }

        public async Task<Operation> GetAsync(Guid id) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            return await apiService.GetByIdAsync(uri);
        }

        public async Task CreateAsync(OperationCreateDTO operation) {
            await apiService.CreateAsync(operation, Resources.ApiOperationUri);
        }

        public async Task UpdateAsync(Guid id, OperationCreateDTO operationDTO) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            await apiService.UpdateAsync(operationDTO, uri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            await apiService.DeleteAsync(uri);
        }

        public Task CreateAsync(Operation item) {
            throw new NotImplementedException();
        }
    }
}
