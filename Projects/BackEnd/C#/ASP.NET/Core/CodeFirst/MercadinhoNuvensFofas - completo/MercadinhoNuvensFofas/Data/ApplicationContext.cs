using MercadinhoNuvensFofas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        { }

        //criar as TABLES
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Bebida> Bebidas { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<FormaEntrega> FormaEntrega { get; set; }
    }
}
