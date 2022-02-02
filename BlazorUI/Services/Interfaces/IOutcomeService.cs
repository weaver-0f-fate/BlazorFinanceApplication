using System.Threading.Tasks;
using Core.Aids;
using Core.Models;

namespace Services.Interfaces {
    public interface IOutcomeService {
        public Task<Outcome> GetOutcomeAtDate(Date date);
        public Task<Outcome> GetOutcomeAtPeriod(Period period);
    }
}
