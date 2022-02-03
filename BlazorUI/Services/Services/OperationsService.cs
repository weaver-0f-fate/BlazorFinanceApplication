using AutoMapper;
using Core.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationsService : IOperationsService {
        private IApiService<Operation> apiService;
        private IMapper mapper;

        public OperationsService(IApiService<Operation> apiService, IMapper mapper) {
            this.apiService = apiService;
            this.mapper = mapper;
        }

        public async Task<List<Operation>> GetAllAsync() {
            return await apiService.GetCollectionByUriAsync(Resources.ApiOperationUri);
        }

        public async Task CreateAsync(Operation operation) {
            var operationDTO = mapper.Map<OperationCreateDTO>(operation);
            await apiService.CreateAsync(operationDTO, Resources.ApiOperationUri);
        }

        public async Task UpdateAsync(Guid id, Operation operation) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            var operationDTO = mapper.Map<OperationCreateDTO>(operation);
            await apiService.UpdateAsync(operationDTO, uri);
        }

        public async Task DeleteAsync(Guid id) {
            var uri = $"{Resources.ApiOperationUri}{id}";
            await apiService.DeleteAsync(uri);
        }
    }
}
