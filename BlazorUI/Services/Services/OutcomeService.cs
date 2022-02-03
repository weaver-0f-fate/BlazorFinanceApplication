using Services.Interfaces;
using System.Threading.Tasks;
using Core.Aids;
using Core.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace Services.Services {
    public class OutcomeService : IOutcomeService {
        private IApiService<Outcome> apiService;
        private Uri outcomeUri;

        public OutcomeService(IApiService<Outcome> apiService, IConfiguration config) {
            this.apiService = apiService;
            var url = config.GetSection("ApiUrl").Value;
            outcomeUri = new Uri($"{url}Outcome/");
        }

        public async Task<Outcome> GetOutcomeAtDate(Date date) {
            var currentDate = date.CurrentDate;
            var uri = $"{outcomeUri}Date/?date={currentDate.Month}.{currentDate.Day}.{currentDate.Year}";
            return await apiService.GetItemByUriAsync(uri);
        }

        public async Task<Outcome> GetOutcomeAtPeriod(Period period) {
            string startDate = $"startDate={period.StartDate.Month}.{period.StartDate.Day}.{period.StartDate.Year}";
            string endDate = $"endDate={period.EndDate.Month}.{period.EndDate.Day}.{period.EndDate.Year}";
            var uri = $"{outcomeUri}Period?{startDate}&{endDate}";

            return await apiService.GetItemByUriAsync(uri);
        }
    }
}
