using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinha.Models
{
    public class Aluno
    {
        
        // não é nescessário as variáveis, apenas as propriedades, coisa do SOLID
        public DateTime DataMatriculaAluno { get; set; }

        [Key]
        [Column("IdAluno")]
        [Display(Name = "Código")]
        public int Id { get ; set ; }

        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Display(Name = "Mensalidade")]
        [Column(TypeName = "decimal (10,2)")]
        public double MensalidadeAluno { get ; set; }

        [Display(Name = "Nome do Aluno")]
        [Column(TypeName="varchar(100)")]
        public string NomeAluno { get ; set ; }

        [Display(Name = "Curso do Aluno")]
        [Column(TypeName = "varchar(15)")]
        public string CursoAluno { get ; set ; }

        [Display(Name = "Gênero do Aluno")]
        public string GeneroAluno { get ; set ; }


        // propriedade de navegação
        public ICollection<Boletim> Boletim { get; set; }
    }
}
