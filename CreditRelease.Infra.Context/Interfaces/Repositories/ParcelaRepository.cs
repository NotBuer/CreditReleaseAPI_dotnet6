﻿namespace CreditRelease.Infra.Context.Interfaces.Repositories
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly AppDbContext _context;

        public ParcelaRepository(AppDbContext context) =>
            _context = context;

        public void CreateParcela(Parcela parcela)
        {
            _context.Parcelas.Add(parcela);
            _context.SaveChanges();
        }

        public void UpdateParcela(Parcela parcela)
        {
            _context.Parcelas.Update(parcela);
            _context.SaveChanges();
        }

        public void DeleteParcela(int id)
        {
            Parcela? parcela = _context.Parcelas.Find(id);
            if (parcela != null)
                _context.Parcelas.Remove(parcela);
            _context.SaveChanges();
        }

        public async Task<Parcela?> GetParcelaById(int id) =>
            await _context.Parcelas.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Parcela>> GetAllParcelas()
        {
            return await _context.Parcelas.ToListAsync();
        }
    }
}
