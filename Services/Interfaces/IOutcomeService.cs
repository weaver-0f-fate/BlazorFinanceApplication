using System;
using System.Threading.Tasks;
using Core.Structs;
using Core.Models;

namespace Services.Interfaces {
    public interface IOutcomeService {
        public Task<Outcome> GetOutcomeAtDate(Date date);
        public Task<Outcome> GetOutcomeAtPeriod(Period period);
    }
}
