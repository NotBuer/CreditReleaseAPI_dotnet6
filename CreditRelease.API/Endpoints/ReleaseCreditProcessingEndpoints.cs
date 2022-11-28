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
                Financiamento result = await _service.CreateAndProcessFinanciamentoForCliente(idCliente, financiamento);
                if (result != null)
                    return Results.Created(Utils.Route_ProcessCredit_POST, result);
                else return Results.BadRequest(result);
            })
                .Produces<Financiamento>(StatusCodes.Status201Created)
                .WithName(nameof(Post) + "CreateAndProcessFinanciamentoForCliente")
                .WithTags(nameof(ReleaseCreditProcessingService));
        }
    }
}
