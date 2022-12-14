namespace CreditRelease.Domain.Interfaces.Repositories
{
    public interface IFinanciamentoRepository
    {
        void CreateFinanciamento(Financiamento financiamento);
        void UpdateFinanciamento(Financiamento financiamento);
        void DeleteFinanciamento(int id);
        Task<Financiamento?> GetFinanciamentoById(int id);
        Task<List<Financiamento>> GetAllFinanciamentos();
        Task<Financiamento?> GetUniqueFinanciamentoByClienteId(int id, int idCliente);
        Task<List<Financiamento>> GetAllFinanciamentosByClienteId(int idCliente);
    }
}