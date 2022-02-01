using Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Task13.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureServices(this IServiceCollection services) {
            services.AddTransient<IApiService<OperationType>, ApiService<OperationType>>();
            services.AddTransient<IApiService<Operation>, ApiService<Operation>>();
            services.AddTransient<IApiService<Outcome>, ApiService<Outcome>>();

            services.AddTransient<IOperationsService, OperationsService>();
            services.AddTransient<IOperationTypesService, OperationTypesService>();
            services.AddTransient<IOutcomeService, OutcomeService>();
        }
    }
}
