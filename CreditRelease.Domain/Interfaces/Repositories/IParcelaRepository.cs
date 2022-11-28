namespace CreditRelease.Domain.Interfaces.Repositories
{
    public interface IParcelaRepository
    {
        void CreateParcela(Parcela parcela);
        Task CreateManyParcelas(ICollection<Parcela> parcelas);
        void UpdateParcela(Parcela parcela);
        void DeleteParcela(int id);
        Task<Parcela?> GetParcelaById(int id);
        Task<List<Parcela>> GetAllParcelas();
        Task<Parcela?> GetUniqueParcelaByFinanciamentoId(int id, int idFinanciamento);
        Task<List<Parcela>> GetAllParcelasByFinanciamentoId(int idFinanciamento);
    }
}
