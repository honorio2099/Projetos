using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas.Models
{
    public class FormaEntrega
    {
        [Key]
        public int IdForma { get; set; }

        [Display(Name = "Descrição")]
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string DescForma { get; set; }

        [Display(Name = "Acréscimo")]
        public int AcrescForma { get; set; }

        //propriedade de navegação => relacionamento entre FORMA E VENDA
        public ICollection<Venda> Venda { get; set; }
    }
}
