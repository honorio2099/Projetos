using System;
using LoginComSession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoginComSession.Data
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
     : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsu)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsu).HasColumnName("idUsu");

                entity.Property(e => e.LoginUsu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("loginUsu");

                entity.Property(e => e.NomeUsu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomeUsu");

                entity.Property(e => e.SenhaUsu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("senhaUsu");

                entity.Property(e => e.TipoUsu)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("tipoUsu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
