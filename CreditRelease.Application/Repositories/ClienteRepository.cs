namespace CreditRelease.Application.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) =>
            _context = context;

        public void CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            Cliente? cliente = _context.Clientes.Find(id);
            if (cliente != null)
                _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public async Task<Cliente?> GetClienteById(int id) =>
            await _context.Clientes.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
