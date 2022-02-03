using Core.Models;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : IOperationTypesService {
        private IApiService<OperationType> apiService;
        private Uri operationTypesUri;

        public OperationTypesService(IApiService<OperationType> apiService, IConfiguration config) {
            this.apiService = apiService;
            var url = config.GetSection("ApiUrl").Value;
            operationTypesUri = new Uri($"{url}OperationTypes/");
        }

        public async Task<List<OperationType>> GetAllAsync() {
            return await apiService.GetCollectionByUriAsync(operationTypesUri.AbsoluteUri);
        }

        public async Task CreateAsync(OperationType operationType) {
            await apiService.CreateAsync(operationType, operationTypesUri.AbsoluteUri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{operationTypesUri.AbsoluteUri}{id}";
            await apiService.DeleteAsync(uri);
        }
    }
}
