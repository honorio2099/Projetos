﻿// <auto-generated />
using System;
using MercadinhoNuvensFofas.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MercadinhoNuvensFofas.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Bebida", b =>
                {
                    b.Property<int>("IdBeb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeBeb")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("PrecoBeb")
                        .HasColumnType("double");

                    b.Property<int>("QtdDispBeb")
                        .HasColumnType("int");

                    b.HasKey("IdBeb");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.FormaEntrega", b =>
                {
                    b.Property<int>("IdForma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcrescForma")
                        .HasColumnType("int");

                    b.Property<string>("DescForma")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("IdForma");

                    b.ToTable("FormaDeEntrega");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Produto", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeProd")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("PrecoProd")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QtdDispProd")
                        .HasColumnType("int");

                    b.HasKey("IdProd");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdBeb")
                        .HasColumnType("int");

                    b.Property<int>("IdForma")
                        .HasColumnType("int");

                    b.Property<int>("IdProp")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("longtext");

                    b.Property<int>("QTDBeb")
                        .HasColumnType("int");

                    b.Property<int>("QTDprod")
                        .HasColumnType("int");

                    b.HasKey("IdVenda");

                    b.HasIndex("IdBeb");

                    b.HasIndex("IdForma");

                    b.HasIndex("IdProp");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Venda", b =>
                {
                    b.HasOne("MercadinhoNuvensFofas.Models.Bebida", "Bebida")
                        .WithMany("Vendas")
                        .HasForeignKey("IdBeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadinhoNuvensFofas.Models.FormaEntrega", "FormaEntrega")
                        .WithMany("Vendas")
                        .HasForeignKey("IdForma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadinhoNuvensFofas.Models.Produto", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("IdProp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bebida");

                    b.Navigation("FormaEntrega");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Bebida", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.FormaEntrega", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("MercadinhoNuvensFofas.Models.Produto", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
