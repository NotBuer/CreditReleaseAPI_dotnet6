namespace CreditRelease.Infra.Context.Mappings
{
    public class FinanciamentoMap : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.ToTable(ContextUtils.TABLE_NAME_Financiamentos)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TipoFinanciamento)
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .IsRequired();

            builder.Property(x => x.QuantidadeParcelas)
                .IsRequired();

            builder.Property(x => x.DataContratacao)
                .IsRequired();

            builder.Property(x => x.VencimentoPrimeiraParcela)
                .IsRequired();

            builder.HasMany(x => x.Parcelas)
                .WithOne(x => x.Financiamento)
                .HasForeignKey(x => x.IdFinanciamento);
        }
    }
}
