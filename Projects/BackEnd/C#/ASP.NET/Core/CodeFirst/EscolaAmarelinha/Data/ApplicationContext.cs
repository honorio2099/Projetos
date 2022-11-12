using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscolaAmarelinha.Models;

namespace EscolaAmarelinha.Data
{
    public class ApplicationContext: DbContext
    {
        // criar construtor padrão
        // sempre será o mesmo

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        // criar as propriedades das models que serão as tables
        // dentro da lista - classe criada e depois o nome da tabela. vai dar erro na classe dentro
        // da lista por não ter o nome do namespace.Models
        public DbSet<Aluno> Alunos { get; set; } // - criação de uma tabela "dentro" do código, sem precisar ficar indo e voltando no Mysql
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Boletim> Boletim { get; set; }
    }
}
