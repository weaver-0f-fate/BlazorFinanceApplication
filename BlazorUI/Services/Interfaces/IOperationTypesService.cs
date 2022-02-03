using Core.Models;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationTypesService : IService<OperationType> {
        public Task CreateAsync(OperationType item);
    }
}
