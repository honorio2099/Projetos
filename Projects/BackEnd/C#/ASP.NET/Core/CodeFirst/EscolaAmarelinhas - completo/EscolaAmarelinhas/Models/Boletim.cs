using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Models
{
    public class Boletim
    {
        [Key]
        public int IdBoletim { get; set; }

        [ForeignKey("Aluno")]
        [Display(Name ="Aluno")]
        public int IdAluno { get; set; }

        [ForeignKey("Disciplina")]
        [Display(Name ="Disciplina")]
        public int IdDisciplina { get; set; }

        [Display(Name ="Nota")]
        public double NotaDisciplina { get; set; }


        public Aluno Aluno { get; set; }

        public Disciplina Disciplina { get; set; }
    }
}
