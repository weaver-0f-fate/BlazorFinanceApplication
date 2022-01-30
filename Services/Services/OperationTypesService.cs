using Core.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : IOperationTypesService {
        public async Task<IEnumerable<OperationType>> GetAllAsync() {
            await Task.Delay(1);
            return new[] {
                new OperationType {
                    Id = new Guid(),
                    IsIncome = true,
                    Name = "Salary"
                    },
                new OperationType {
                    Id = new Guid(),
                    IsIncome = false,
                    Name = "Taxes"
                }
            };
        }
        public async Task<OperationType> GetAsync(Guid id) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
        public async Task CreateAsync(OperationType item) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(OperationType item) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(Guid id) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
}
