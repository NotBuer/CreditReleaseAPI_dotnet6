namespace CreditRelease.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
        Task<Cliente?> GetClienteById(int id);
        Task<List<Cliente>> GetAllClientes();
    }
}
