using EscolaAmarelinhas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Data
{
    public class ApplicationContext : DbContext
    {
        // construtor padrão
        // SEMPRE SERÁ O MESMO PARA QUALQUER EXEMPLO
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        ///////////////////////////////////////////////////////////////////

        // criar as propriedades das MODELS que serão as TABLES
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<Boletim> Boletim { get; set; }
    }
}
