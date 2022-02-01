using Core.Models;
using Services.DTO;
using System;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation> {
        public Task UpdateAsync(Guid id, OperationCreateDTO operation);
        public Task CreateAsync(OperationCreateDTO item);
    }
}
