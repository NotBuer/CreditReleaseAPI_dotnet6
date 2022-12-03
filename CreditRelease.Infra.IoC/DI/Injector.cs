using Microsoft.Extensions.DependencyInjection;
using CreditRelease.Infra.Repositories.Repositories;
using CreditRelease.Infra.Services;

namespace CreditRelease.Infra.IoC.DI
{
    public static class DependecyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ClienteRepository>();
            services.AddScoped<FinanciamentoRepository>();
            services.AddScoped<ParcelaRepository>();

            services.AddScoped<ReleaseCreditProcessingService>();
        }
    }
}
