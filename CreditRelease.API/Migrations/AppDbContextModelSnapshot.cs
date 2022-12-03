﻿// <auto-generated />
using System;
using CreditRelease.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditRelease.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreditRelease.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<long>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Financiamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<byte>("QuantidadeParcelas")
                        .HasColumnType("tinyint");

                    b.Property<byte>("StatusCredito")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TipoFinanciamento")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UltimoVencimento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTaxa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotalComTaxa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VencimentoPrimeiraParcela")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Financiamentos", (string)null);
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFinanciamento")
                        .HasColumnType("int");

                    b.Property<byte>("NumeroDaParcela")
                        .HasColumnType("tinyint");

                    b.Property<bool>("ParcelaPaga")
                        .HasColumnType("bit");

                    b.Property<decimal>("ValorDaParcela")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdFinanciamento");

                    b.ToTable("Parcelas", (string)null);
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Financiamento", b =>
                {
                    b.HasOne("CreditRelease.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Financiamentos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Parcela", b =>
                {
                    b.HasOne("CreditRelease.Domain.Entities.Financiamento", "Financiamento")
                        .WithMany("Parcelas")
                        .HasForeignKey("IdFinanciamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Financiamento");
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Financiamentos");
                });

            modelBuilder.Entity("CreditRelease.Domain.Entities.Financiamento", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
