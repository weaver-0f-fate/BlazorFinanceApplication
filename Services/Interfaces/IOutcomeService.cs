using System;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOutcomeService {
        public Task GetOutcomeAtDate(DateTime date);
        public Task GetOutcomeAtPeriod(DateTime startDate, DateTime endDate);
    }
}
