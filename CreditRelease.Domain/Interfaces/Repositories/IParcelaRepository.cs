namespace CreditRelease.Domain.Interfaces.Repositories
{
    public interface IParcelaRepository
    {
        void CreateParcela(Parcela parcela);
        void UpdateParcela(Parcela parcela);
        void DeleteParcela(int id);
        Task<Parcela?> GetParcelaById(int id);
        Task<List<Parcela>> GetAllParcelas();
    }
}
