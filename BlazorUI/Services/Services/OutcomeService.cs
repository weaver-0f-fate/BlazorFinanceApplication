﻿using Services.Interfaces;
using System.Threading.Tasks;
using Core.Aids;
using Core.Models;
using Services.Properties;

namespace Services.Services {
    public class OutcomeService : IOutcomeService {
        private IApiService<Outcome> apiService;

        public OutcomeService(IApiService<Outcome> apiService) {
            this.apiService = apiService;
        }

        public async Task<Outcome> GetOutcomeAtDate(Date date) {
            var currentDate = date.CurrentDate;
            var uri = $"{Resources.ApiOutcomeUri}Date/?date={currentDate.Month}.{currentDate.Day}.{currentDate.Year}";
            return await apiService.GetItemByUriAsync(uri);
        }

        public async Task<Outcome> GetOutcomeAtPeriod(Period period) {
            string startDate = $"startDate={period.StartDate.Month}.{period.StartDate.Day}.{period.StartDate.Year}";
            string endDate = $"endDate={period.EndDate.Month}.{period.EndDate.Day}.{period.EndDate.Year}";
            var uri = $"{Resources.ApiOutcomeUri}Period?{startDate}&{endDate}";

            return await apiService.GetItemByUriAsync(uri);
        }
    }
}