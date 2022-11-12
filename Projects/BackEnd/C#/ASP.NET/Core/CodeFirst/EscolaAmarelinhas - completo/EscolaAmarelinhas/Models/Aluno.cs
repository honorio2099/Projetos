using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        [Column("IdAluno")]
        [Display(Name ="Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column(TypeName ="varchar(100)")]
        public string NomeAluno { get; set; }

        [Display(Name = "Curso")]
        [Column(TypeName = "varchar(50)")]
        public string CursoAluno { get; set; }

        [Display(Name = "Sexo")]
        [Column(TypeName = "varchar(15)")]
        public string SexoAluno { get; set; }

        [Display(Name = "Idade")]
        public int IdadeAluno { get; set; }

        [Display(Name = "Mensalidade")]
        [Column(TypeName = "decimal(10,2)")]
        public double MensalidadeAluno { get; set; }

        [Display(Name = "Data de Matrícula")]
        [DataType(DataType.Date)]
        public DateTime DataMatriculaAluno { get; set; }

        //propriedade de Navegação
        public ICollection<Boletim> Boletim { get; set; }

       
    }
}
