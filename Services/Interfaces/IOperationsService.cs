using Core.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation> {
        
        public Task<IEnumerable<Operation>> GetAllAtDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetAllAtPeriodAsync(DateTime startDate, DateTime endDate);
        public Task CreateAsync(OperationCreateDTO operation);
        public Task UpdateAsync(Guid id, OperationCreateDTO operation);
    }
}
