namespace CreditRelease.Infra.Context.Mappings
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable(ContextUtils.TABLE_NAME_Parcelas)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NumeroDaParcela)
                .IsRequired();

            builder.Property(x => x.ValorDaParcela)
                .IsRequired();

            builder.Property(x => x.DataVencimento)
                .IsRequired();
        }
    }
}
