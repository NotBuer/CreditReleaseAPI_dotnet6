using Microsoft.IdentityModel.Tokens;

namespace CreditRelease.API.Endpoints
{
    public static class ParcelaEndpoints
    {
        public static void Map(WebApplication app)
        {
            ParcelaEndpointsMap(app);
        }

        private static void ParcelaEndpointsMap(WebApplication app)
        {
            Post(app);
            PostMany(app);
            GetById(app);
            GetAll(app);
            GetUniqueByFinanciamentoId(app);
            GetAllByFinanciamentoId(app);
            Put(app);
            Delete(app);
        }

        private static void Post(WebApplication app)
        {
            app.MapPost(Utils.Route_Parcela_POST, (ParcelaRepository _repository, Parcela parcela) =>
            {
                _repository.CreateParcela(parcela);
                return Results.Created(Utils.Route_Parcela_POST, parcela);
            })
                .Produces<Parcela>(StatusCodes.Status201Created)
                .WithName(nameof(Post) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void PostMany(WebApplication app)
        {
            app.MapPost(Utils.Route_Parcela_POSTMany, async (ParcelaRepository _repository, ICollection<Parcela> parcelas) =>
            {
                await _repository.CreateManyParcelas(parcelas);
                return Results.Created(Utils.Route_Parcela_POSTMany, parcelas);
            })
                .Produces<ICollection<Parcela>>(StatusCodes.Status201Created)
                .WithName(nameof(PostMany) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void GetById(WebApplication app)
        {
            app.MapGet(Utils.Route_Parcela_GetByID, async (ParcelaRepository _repository, int id) =>
            {
                Parcela? parcela = await _repository.GetParcelaById(id);
                return Results.Ok(parcela);
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(GetById) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void GetAll(WebApplication app)
        {
            app.MapGet(Utils.Route_Parcela_GetAll, async (ParcelaRepository _repository) =>
            {
                List<Parcela> parcela = await _repository.GetAllParcelas();
                if (!parcela.IsNullOrEmpty())
                    return Results.Ok(parcela);
                else
                    return Results.NoContent();
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(GetAll) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void GetUniqueByFinanciamentoId(WebApplication app)
        {
            app.MapGet(Utils.Route_Parcela_GetUniqueParcelaByFinanciamentoID, async (ParcelaRepository _repository, int id, int idFinanciamento) =>
            {
                Parcela? parcela = await _repository.GetUniqueParcelaByFinanciamentoId(id, idFinanciamento);
                if (parcela != null)
                    return Results.Ok(parcela);
                else return Results.NoContent();
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(GetUniqueByFinanciamentoId) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void GetAllByFinanciamentoId(WebApplication app)
        {
            app.MapGet(Utils.Route_Parcela_GetParcelasByFinanciamentoID, async (ParcelaRepository _repository, int idFinanciamento) =>
            {
                List<Parcela> parcelas = await _repository.GetAllParcelasByFinanciamentoId(idFinanciamento);
                if (!parcelas.IsNullOrEmpty())
                    return Results.Ok(parcelas);
                else return Results.NoContent();
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(GetAllByFinanciamentoId) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void Put(WebApplication app)
        {
            app.MapPut(Utils.Route_Parcela_PUT, (ParcelaRepository _repository, Parcela parcela) =>
            {
                _repository.UpdateParcela(parcela);
                return Results.Ok(parcela);
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(Put) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }

        private static void Delete(WebApplication app)
        {
            app.MapDelete(Utils.Route_Parcela_DELETE, (ParcelaRepository _repository, int id) =>
            {
                _repository.DeleteParcela(id);
                return Results.Ok();
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(Delete) + nameof(Parcela))
                .WithTags(nameof(Parcela));
        }
    }
}
