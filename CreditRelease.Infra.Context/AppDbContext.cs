namespace CreditRelease.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Financiamento> Financiamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FinanciamentoMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());
        }
    }
}
