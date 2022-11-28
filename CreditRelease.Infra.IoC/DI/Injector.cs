using CreditRelease.Domain.Interfaces.Repositories;
using CreditRelease.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CreditRelease.Application.Services;

namespace CreditRelease.Infra.IoC.DI
{
    public static class Injector
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
