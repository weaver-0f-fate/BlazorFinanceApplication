using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services {
    public class ApiService<T> : IApiService<T> {
        public Task CreateAsync(T item) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id) {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item) {
            throw new NotImplementedException();
        }
    }
}
