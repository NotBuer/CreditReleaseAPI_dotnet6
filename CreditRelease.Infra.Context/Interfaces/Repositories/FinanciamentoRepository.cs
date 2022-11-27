namespace CreditRelease.Infra.Context.Interfaces.Repositories
{
    public class FinanciamentoRepository : IFinanciamentoRepository
    {
        private readonly AppDbContext _context;

        public FinanciamentoRepository(AppDbContext context) =>
            _context = context;

        public void CreateFinanciamento(Financiamento financiamento)
        {
            _context.Financiamentos.Add(financiamento);
            _context.SaveChanges();
        }

        public void UpdateFinanciamento(Financiamento financiamento)
        {
            _context.Financiamentos.Update(financiamento);
            _context.SaveChanges();
        }

        public void DeleteFinanciamento(int id)
        {
            Financiamento? financiamento = _context.Financiamentos.Find(id);
            if (financiamento != null)
                _context.Financiamentos.Remove(financiamento);
            _context.SaveChanges();
        }

        public async Task<Financiamento?> GetFinanciamentoById(int id) =>
            await _context.Financiamentos.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Financiamento>> GetAllFinanciamentos()
        {
            return await _context.Financiamentos.ToListAsync();
        }
    }
}
