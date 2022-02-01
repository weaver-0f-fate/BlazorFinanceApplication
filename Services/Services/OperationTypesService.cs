using Core.Models;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : IOperationTypesService {
        private IApiService<OperationType> apiService;

        public OperationTypesService(IApiService<OperationType> apiService) {
            this.apiService = apiService;
        }

        public async Task<List<OperationType>> GetAllAsync() {
            return await apiService.GetCollectionByUriAsync(Resources.ApiOperationTypeUri);
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
