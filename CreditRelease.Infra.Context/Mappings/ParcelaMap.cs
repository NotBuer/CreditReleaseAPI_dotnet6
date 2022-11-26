﻿namespace CreditRelease.Infra.Context.Mappings
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable(nameof(Parcela))
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NumeroDaParcela)
                .IsRequired();

            builder.Property(x => x.ValorDaParcela)
                .IsRequired();

            builder.Property(x => x.DataVencimento)
                .IsRequired();

            builder.Property(x => x.DataPagamento)
                .IsRequired();
        }
    }
}
