using CreditRelease.Domain.Interfaces.Repositories;
using CreditRelease.Infra.Context.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CreditRelease.Infra.IoC.DI
{
    public static class Injector
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ClienteRepository>();
            services.AddScoped<FinanciamentoRepository>();
            services.AddScoped<ParcelaRepository>();
        }
    }
}
