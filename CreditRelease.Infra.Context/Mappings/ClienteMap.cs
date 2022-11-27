namespace CreditRelease.Infra.Context.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente))
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.CPF)
                .HasMaxLength(11).IsRequired();

            builder.Property(x => x.UF)
                .HasMaxLength(25).IsRequired();

            builder.Property(x => x.Celular)
                .HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Financiamentos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
