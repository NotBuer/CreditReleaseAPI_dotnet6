namespace CreditRelease.API.Endpoints
{
    public static class ClienteEndpoints
    {

        public static void Map(WebApplication app)
        {
            ClienteEndpointsMap(app);
        }

        private static void ClienteEndpointsMap(WebApplication app)
        {
            Post(app);
            GetById(app);
            GetAll(app);
            Put(app);
            Delete(app);
        }

        private static void Post(WebApplication app)
        {
            app.MapPost(Utils.Route_Cliente_POST, (ClienteRepository _repository, Cliente cliente) =>
            {
                _repository.CreateCliente(cliente);
                return Results.Created(Utils.Route_Cliente_POST, cliente);
            })
                .Produces<Cliente>(StatusCodes.Status201Created)
                .WithName(nameof(Post) + nameof(Cliente))
                .WithTags(nameof(Cliente));
        }

        private static void GetById(WebApplication app)
        {
            app.MapGet(Utils.Route_Cliente_GetByID, async (ClienteRepository _repository, int id) =>
            {
                Cliente? cliente = await _repository.GetClienteById(id);
                return Results.Ok(cliente);
            })
                .Produces<Cliente>(StatusCodes.Status200OK)
                .WithName(nameof(GetById) + nameof(Cliente))
                .WithTags(nameof(Cliente));
        }

        private static void GetAll(WebApplication app)
        {
            app.MapGet(Utils.Route_Cliente_GetAll, async (ClienteRepository _repository) =>
            {
                List<Cliente> clientes = await _repository.GetAllClientes();
                if (clientes.Count > 0)
                    return Results.Ok(clientes);
                else 
                    return Results.NoContent();
            })
                .Produces<Cliente>(StatusCodes.Status200OK)
                .WithName(nameof(GetAll) + nameof(Cliente))
                .WithTags(nameof(Cliente));
        }

        private static void Put(WebApplication app)
        {
            app.MapPut(Utils.Route_Cliente_PUT, (ClienteRepository _repository, Cliente cliente) =>
            {
                _repository.UpdateCliente(cliente);
                return Results.Ok(cliente);
            })
                .Produces<Cliente>(StatusCodes.Status200OK)
                .WithName(nameof(Put) + nameof(Cliente))
                .WithTags(nameof(Cliente));
        }

        private static void Delete(WebApplication app)
        {
            app.MapDelete(Utils.Route_Cliente_DELETE, (ClienteRepository _repository, int id) =>
            {
                _repository.DeleteCliente(id);
                return Results.Ok();
            })
                .Produces<Cliente>(StatusCodes.Status200OK)
                .WithName(nameof(Delete) + nameof(Cliente))
                .WithTags(nameof(Cliente));
        }
    }
}
