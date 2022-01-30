using Core.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationsService : IOperationsService {
        public async Task<IEnumerable<Operation>> GetAllAsync() {
            await Task.Delay(1);
            return new[] {
                new Operation {
                    Id = new Guid(),
                    Name = "First Operation",
                    OperationType = new OperationType {
                        Id = new Guid(),
                        IsIncome = true,
                        Name = "Salary"
                    },
                    Date = DateTime.Now,
                    Amount = 5000
                    },
                new Operation {
                    Id = new Guid(),
                    Name = "Second Operation",
                    OperationType = new OperationType {
                        Id = new Guid(),
                        IsIncome = false,
                        Name = "Taxes"
                    },
                    Date = DateTime.Now,
                    Amount = 500
                }
            };
        }

        public async Task<IEnumerable<Operation>> GetAllAtDateAsync(DateTime date) {
            await Task.Delay(1);
            //TODO
            return null;
        }

        public async Task<IEnumerable<Operation>> GetAllAtPeriodAsync(DateTime startDate, DateTime endDate) {
            await Task.Delay(1);
            //TODO
            return null;
        }

        public async Task<Operation> GetAsync(Guid id) {
            await Task.Delay(1);
            //TODO
            return new Operation {
                Id = new Guid(),
                Name = "Second Operation",
                OperationType = new OperationType {
                    Id = new Guid(),
                    IsIncome = false,
                    Name = "Taxes"
                },
                Date = DateTime.Now,
                Amount = 500
            };
        }

        public async Task CreateAsync(Operation operation) {
            await Task.Delay(1);
            //TODO
        }

        public async Task UpdateAsync(Operation operation) {
            await Task.Delay(1);
            //TODO
        }

        public async Task DeleteAsync(Guid id) {
            await Task.Delay(1);
            //TODO
        }
    }
}
