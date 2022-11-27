using CreditRelease.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CreditRelease.API.Extensions
{
    public static class DBConnection
    {

        private const string DEFAULT_CONNECTION = "Context";

        public static WebApplicationBuilder BuilderAddDbContext(this WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString(DEFAULT_CONNECTION);
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("CreditRelease.API")));
            return builder;
        }

    }
}
