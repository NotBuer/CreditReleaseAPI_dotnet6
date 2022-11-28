namespace CreditRelease.Domain.Interfaces.Services
{
    public interface IReleaseCreditProcessingService
    {
        Task<Financiamento> CreateAndProcessFinanciamentoForCliente(int idCliente, Financiamento financiamento);
    }
}
