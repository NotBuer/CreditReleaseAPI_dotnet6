using CreditRelease.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CreditRelease.API.Extensions
{
    public static class DBConnection
    {

        private const string DEFAULT_CONNECTION = "Context";
        private const string DEVELOPMENT_CONNECTION = "ContextDev";
        private const string PRODUCTION_CONNECTION = "ContextProd";

        public static WebApplicationBuilder BuilderAddDbContext(this WebApplicationBuilder builder)
        {
            string? connectionString;

            connectionString = builder.Environment.IsDevelopment() ?
                builder.Configuration.GetConnectionString(DEVELOPMENT_CONNECTION) :
                (builder.Environment.IsProduction() ? builder.Configuration.GetConnectionString(PRODUCTION_CONNECTION) : builder.Configuration.GetConnectionString(DEFAULT_CONNECTION));

            builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionString));
            return builder;
        }

    }
}
