using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Models
{
    public class Professor
    {
        [Key]
        public int IdProf{ get; set; }

        [Column (TypeName ="varchar(100)")]
        public string NomeProf { get; set; }

        public int IdadeProf { get; set; }

        public double SalarioProf { get; set; }

        [Display(Name ="Professor ativo na instituição?")]
        public Boolean StatusProf { get; set; }

        public string VerificarStatus()
        {
            if (StatusProf == true)
            {
                return "Sim";
            }
            else
            {
                return "Não";
            }
        }
    }
}
