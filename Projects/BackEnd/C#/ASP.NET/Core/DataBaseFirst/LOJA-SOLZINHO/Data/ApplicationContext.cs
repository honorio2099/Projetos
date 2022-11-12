using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LOJA_SOLZINHO.Models;

#nullable disable

namespace LOJA_SOLZINHO.Data
{
    public partial class ApplicationContext : DbContext
    {
       
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormaPagto> FormaPagtos { get; set; }
        public virtual DbSet<ItemVenda> ItemVendas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<TipoProd> TipoProds { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=lojas;uid=root;pwd=griloseco347", Microsoft.EntityFrameworkCore.
                    ServerVersion.Parse("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<FormaPagto>(entity =>
            {
                entity.HasKey(e => e.IdPagto)
                    .HasName("PRIMARY");

                entity.ToTable("forma_pagto");

                entity.Property(e => e.IdPagto).HasColumnName("id_pagto");

                entity.Property(e => e.TipoPagto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipo_pagto");
            });

            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey(e => e.IdItemVenda)
                    .HasName("PRIMARY");

                entity.ToTable("item_vendas");

                entity.HasIndex(e => e.IdProd, "id_prod");

                entity.HasIndex(e => e.IdVenda, "id_venda");

                entity.Property(e => e.IdItemVenda).HasColumnName("id_item_venda");

                entity.Property(e => e.IdProd).HasColumnName("id_prod");

                entity.Property(e => e.IdVenda).HasColumnName("id_venda");

                entity.Property(e => e.QtdItem).HasColumnName("qtd_item");

                entity.Property(e => e.TotalItem)
                    .HasPrecision(8, 2)
                    .HasColumnName("total_item");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.ItemVenda)
                    .HasForeignKey(d => d.IdProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_vendas_ibfk_2");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.ItemVenda)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_vendas_ibfk_1");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PRIMARY");

                entity.ToTable("produto");

                entity.HasIndex(e => e.IdTipo, "id_tipo");

                entity.Property(e => e.IdProd).HasColumnName("id_prod");

                entity.Property(e => e.DescProd)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("desc_prod");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Image1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("image1");

                entity.Property(e => e.NomeProd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("nome_prod");

                entity.Property(e => e.Qtd).HasColumnName("qtd");

                entity.Property(e => e.ValorProd)
                    .HasPrecision(8, 2)
                    .HasColumnName("valor_prod");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_ibfk_1");
            });

            modelBuilder.Entity<TipoProd>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_prod");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.PorcAumento).HasColumnName("porc_aumento");

                entity.Property(e => e.TipoProd1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tipo_prod");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsu)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsu).HasColumnName("id_usu");

                entity.Property(e => e.LoginUsu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("login_usu");

                entity.Property(e => e.NomeUsu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome_usu");

                entity.Property(e => e.SenhaUsu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("senha_usu");

                entity.Property(e => e.TipoUsu)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipo_usu");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PRIMARY");

                entity.ToTable("vendas");

                entity.HasIndex(e => e.IdPagto, "id_pagto");

                entity.HasIndex(e => e.IdUsu, "id_usu");

                entity.Property(e => e.IdVenda).HasColumnName("id_venda");

                entity.Property(e => e.IdPagto).HasColumnName("id_pagto");

                entity.Property(e => e.IdUsu).HasColumnName("id_usu");

                entity.Property(e => e.ValorVnd)
                    .HasPrecision(8, 2)
                    .HasColumnName("valor_vnd");

                entity.HasOne(d => d.IdPagtoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdPagto)
                    .HasConstraintName("vendas_ibfk_2");

                entity.HasOne(d => d.IdUsuNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vendas_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
