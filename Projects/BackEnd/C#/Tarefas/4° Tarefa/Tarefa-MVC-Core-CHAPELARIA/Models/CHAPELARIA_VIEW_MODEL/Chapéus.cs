using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_MVC_Core_CHAPELARIA.Models.CHAPELARIA_VIEW_MODEL
{
    public class Chapéus
    {
        [Key]
        [Column("Id_chapéu")]
        [Display(Name = "Identificação do Chapéu")]
        public int Id_hat { get; set; }

        [Column("varchar(100)")]
        [Display(Name = "Nome do Chapéu")]
        [Required(ErrorMessage = "Favor informar o Nome do Chapéu")]
        public string Nome_Chapéu { get; set; }

        [Column("varchar(100)")]
        [Display(Name = "Cor do Chapéu")]
        [Required(ErrorMessage = "Favor informar a Cor do Chapéu")]
        public string Cor_Chapéu { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Quantidade de Chapéus Disponíveis")]
        [Required(ErrorMessage = "Favor informar a Quantidade de Chapéus Disponíveis")]
        public int QtdAvailable { get; set; }

        [Column(TypeName = "float")]
        [Display(Name = "Preço do Chapéu")]
        [Required(ErrorMessage = "Favor informar o Preço do Chapéu")]
        public double Price { get; set; } 

        // deixar double e mudar o estado da vírgula e ponto no Startup, ou, deixar como string e converter na volta para fazer
        // a conta no calcular? A questão é que aí deveria ficar no HttpPost né? o que eu deixei no GET não contaria pois
        // Para fazer a conversão seria nescessário um reset no site

    }
}
