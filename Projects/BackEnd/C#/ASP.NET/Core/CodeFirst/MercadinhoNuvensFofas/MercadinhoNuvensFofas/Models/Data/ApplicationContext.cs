using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MercadinhoNuvensFofas.Models.Data
{
    public class ApplicationContext : DbContext
    {
        // construtor padrão
        // SEMPRE SERÁ O MESMO PARA QUALQUER EXEMPLO
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        ///////////////////////////////////////////////////////////////////

        // criar as propriedades das MODELS que serão as TABLES
        public DbSet<FormaEntrega> FormaDeEntrega { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

       
    }
}
