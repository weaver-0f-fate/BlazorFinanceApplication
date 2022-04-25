using Core.Models;
using Services.DTO;
using System;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation> {
        public Task UpdateAsync(Guid id, Operation operation);
        public Task CreateAsync(Operation item);
        public Task DeleteAllAsync();
    }
}
