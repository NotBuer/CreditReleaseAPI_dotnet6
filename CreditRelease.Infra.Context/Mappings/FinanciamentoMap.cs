namespace CreditRelease.Infra.Context.Mappings
{
    public class FinanciamentoMap : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.ToTable(nameof(Financiamento))
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CPF)
                .HasMaxLength(11).IsRequired();

            builder.Property(x => x.TipoFinanciamento)
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .IsRequired();

            builder.Property(x => x.UltimoVencimento)
                .IsRequired();

            builder.HasMany(x => x.Parcelas)
                .WithOne(x => x.Financiamento)
                .HasForeignKey(x => x.IdFinanciamento);
        }
    }
}
