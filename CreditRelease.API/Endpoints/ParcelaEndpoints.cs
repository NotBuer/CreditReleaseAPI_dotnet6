﻿namespace CreditRelease.API.Endpoints
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
            GetById(app);
            GetAll(app);
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
                if (parcela.Count > 0)
                    return Results.Ok(parcela);
                else
                    return Results.NoContent();
            })
                .Produces<Parcela>(StatusCodes.Status200OK)
                .WithName(nameof(GetAll) + nameof(Parcela))
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
