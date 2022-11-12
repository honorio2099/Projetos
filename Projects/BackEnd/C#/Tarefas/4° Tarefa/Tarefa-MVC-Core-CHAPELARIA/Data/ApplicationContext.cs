using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarefa_MVC_Core_CHAPELARIA.Models;


namespace Tarefa_MVC_Core_CHAPELARIA.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // lembrar de fazer migrações no final


        // abaixo as tabelas, lembrando que seus nomes serão o que eu colocar aqui
        public DbSet<Vendas> Vendas { get; set; }
    }
}
