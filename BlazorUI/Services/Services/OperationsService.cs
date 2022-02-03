using AutoMapper;
using Core.Models;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Services.Services {
    public class OperationsService : IOperationsService {
        private IApiService<Operation> apiService;
        private IMapper mapper;
        private Uri operationsUri;

        public OperationsService(IApiService<Operation> apiService, IMapper mapper, IConfiguration config) {
            this.apiService = apiService;
            this.mapper = mapper;
            var url = config.GetSection("ApiUrl").Value;
            operationsUri = new Uri($"{url}Operations/");
        }

        public async Task<List<Operation>> GetAllAsync() {
            return await apiService.GetCollectionByUriAsync(operationsUri.AbsoluteUri);
        }

        public async Task CreateAsync(Operation operation) {
            var operationDTO = mapper.Map<OperationCreateDTO>(operation);
            await apiService.CreateAsync(operationDTO, operationsUri.AbsoluteUri);
        }

        public async Task UpdateAsync(Guid id, Operation operation) {
            var uri = $"{operationsUri.AbsoluteUri}{id}";
            var operationDTO = mapper.Map<OperationCreateDTO>(operation);
            await apiService.UpdateAsync(operationDTO, uri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{operationsUri.AbsoluteUri}{id}";
            await apiService.DeleteAsync(uri);
        }
    }
}
