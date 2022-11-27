using CreditRelease.API.Endpoints;

namespace CreditRelease.API.Mapping
{
    public static class Mapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            ClienteEndpoints.Map(app);
            FinanciamentoEndpoints.Map(app);
            ParcelaEndpoints.Map(app);
        }
    }
}
