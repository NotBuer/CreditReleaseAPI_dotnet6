namespace CreditRelease.API.Endpoints
{
    public static class ReleaseCreditProcessingEndpoints
    {
        public static void Map(WebApplication app)
        {
            ReleaseCreditProcessingEndpointsMap(app);
        }

        public static void ReleaseCreditProcessingEndpointsMap(WebApplication app)
        {
            Post(app);
        }

        private static void Post(WebApplication app)
        {
            app.MapPost(Utils.Route_ProcessCredit_POST, async (ReleaseCreditProcessingService _service, int idCliente, Financiamento financiamento) =>
            {
                await _service.CreateAndProcessFinanciamentoForCliente(idCliente, financiamento);
                return Results.Created(Utils.Route_ProcessCredit_POST, financiamento);
            })
                .Produces<Financiamento>(StatusCodes.Status201Created)
                .WithName(nameof(Post) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }
    }
}
