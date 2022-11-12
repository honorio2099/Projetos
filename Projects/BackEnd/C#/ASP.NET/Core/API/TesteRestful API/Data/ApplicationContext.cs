using TesteRestful_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteRestful_API.Data
{
    public class ApplicationContext : DbContext
    {
        // construtor padrão
        // SEMPRE SERÁ O MESMO PARA QUALQUER EXEMPLO
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        ///////////////////////////////////////////////////////////////////

        // criar as propriedades das MODELS que serão as TABLES
        public DbSet<Brinquedo> Brinquedos { get; set; }

    }
}
