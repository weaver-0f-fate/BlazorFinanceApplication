using Core.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation> {
        public Task CreateAsync(OperationCreateDTO operation);
        public Task UpdateAsync(Guid id, OperationCreateDTO operation);
    }
}
