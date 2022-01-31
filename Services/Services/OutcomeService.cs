using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Services.Services {
    public class OutcomeService : IOutcomeService {
        public Task GetOutcomeAtDate(DateTime date) {
            throw new NotImplementedException();
        }

        public Task GetOutcomeAtPeriod(DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }
    }
}
