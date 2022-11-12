using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas.Models
{
    public class Bebida
    {
        [Key]
        public int IdBeb { get; set; }

        [Display(Name = "Nome do Produto")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string NomeBeb { get; set; }

        [Display(Name = "Estoque")]
        public int QtdDispBeb { get; set; }

        [Display(Name = "Preço")]
        public double PrecoBeb { get; set; }

        [Display(Name = "Imagem")]
        [Column(TypeName = "varchar(100)")]
        public string ImgBeb { get; set; }

        //propriedade de navegação => relacionamento entre BEBIDA E VENDA
        public ICollection<Venda> Venda { get; set; }
    }
}
