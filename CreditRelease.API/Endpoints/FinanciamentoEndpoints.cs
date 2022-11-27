using Microsoft.IdentityModel.Tokens;

namespace CreditRelease.API.Endpoints
{
    public static class FinanciamentoEndpoints
    {
        public static void Map(WebApplication app)
        {
            FinanciamentoEndpointsMap(app);
        }

        private static void FinanciamentoEndpointsMap(WebApplication app)
        {
            Post(app);
            GetById(app);
            GetAll(app);
            GetUniqueByClienteId(app);
            GetAllByClienteId(app);
            Put(app);
            Delete(app);
        }

        private static void Post(WebApplication app)
        {
            app.MapPost(Utils.Route_Financiamento_POST, (FinanciamentoRepository _repository, Financiamento financiamento) =>
            {
                _repository.CreateFinanciamento(financiamento);
                return Results.Created(Utils.Route_Financiamento_POST, financiamento);
            })
                .Produces<Financiamento>(StatusCodes.Status201Created)
                .WithName(nameof(Post) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void GetById(WebApplication app)
        {
            app.MapGet(Utils.Route_Financiamento_GetByID, async (FinanciamentoRepository _repository, int id) =>
            {
                Financiamento? financiamento = await _repository.GetFinanciamentoById(id);
                return Results.Ok(financiamento);
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(GetById) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void GetAll(WebApplication app)
        {
            app.MapGet(Utils.Route_Financiamento_GetAll, async (FinanciamentoRepository _repository) =>
            {
                List<Financiamento> financiamentos = await _repository.GetAllFinanciamentos();
                if (!financiamentos.IsNullOrEmpty())
                    return Results.Ok(financiamentos);
                else
                    return Results.NoContent();
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(GetAll) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void GetUniqueByClienteId(WebApplication app)
        {
            app.MapGet(Utils.Route_Financiamento_GetUniqueFinanciamentoByClienteID, async (FinanciamentoRepository _repository, int id, int idCliente) =>
            {
                Financiamento? financiamento = await _repository.GetUniqueFinanciamentoByClienteId(id, idCliente);
                if (financiamento != null)
                    return Results.Ok(financiamento);
                else return Results.NoContent();
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(GetUniqueByClienteId) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void GetAllByClienteId(WebApplication app)
        {
            app.MapGet(Utils.Route_Financiamento_GetFinanciamentosByClienteID, async (FinanciamentoRepository _repository, int idCliente) =>
            {
                List<Financiamento> financiamentos = await _repository.GetAllFinanciamentosByClienteId(idCliente);
                if (!financiamentos.IsNullOrEmpty())
                    return Results.Ok(financiamentos);
                else
                    return Results.NoContent();
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(GetAllByClienteId) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void Put(WebApplication app)
        {
            app.MapPut(Utils.Route_Financiamento_PUT, (FinanciamentoRepository _repository, Financiamento financiamento) =>
            {
                _repository.UpdateFinanciamento(financiamento);
                return Results.Ok(financiamento);
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(Put) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }

        private static void Delete(WebApplication app)
        {
            app.MapDelete(Utils.Route_Financiamento_DELETE, (FinanciamentoRepository _repository, int id) =>
            {
                _repository.DeleteFinanciamento(id);
                return Results.Ok();
            })
                .Produces<Financiamento>(StatusCodes.Status200OK)
                .WithName(nameof(Delete) + nameof(Financiamento))
                .WithTags(nameof(Financiamento));
        }
    }
}
