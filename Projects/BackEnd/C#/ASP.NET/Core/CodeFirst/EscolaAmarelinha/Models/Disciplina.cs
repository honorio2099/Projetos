using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinha.Models
{
    public class Disciplina
    {

        [Key]
        public int idDisciplina { get; set; }

        [Display(Name = "Disciplina")]
        [Column(TypeName = "varchar(50)")]
        public string NomeDisciplina { get; set; }


        public ICollection<Boletim> Boletim { get; set; }
    }
}
