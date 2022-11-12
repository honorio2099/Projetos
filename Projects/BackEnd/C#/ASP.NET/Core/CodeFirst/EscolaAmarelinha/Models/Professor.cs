using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EscolaAmarelinha.Models
{
    public class Professor
    {
        int idProf, idadeProf;
        string nomeProf;
        double salario;
        Boolean statusProf;

        [Key]
        public int IdProf { get => idProf; set => idProf = value; }
        public int IdadeProf { get => idadeProf; set => idadeProf = value; }

        [Column (TypeName = "varchar(100)")]
        public string NomeProf { get => nomeProf; set => nomeProf = value; }
        public double Salario { get => salario; set => salario = value; }

        [Display(Name ="Professor Ativo na Instituição?")]
        public bool StatusProf { get => statusProf; set => statusProf = value; }

        public string VerificarStatus()
             {
                  if(StatusProf == true)
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
