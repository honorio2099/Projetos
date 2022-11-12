using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas.Models
{
    public class Produto
    {
        [Key]
        public int IdProd { get; set; }

        [Display(Name = "Nome do Produto")]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string NomeProd { get; set; }

        [Display(Name = "Estoque")]
        public int QtdDispProd { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public double PrecoProd
        {
            get; set;
        }

        [Display(Name = "Imagem")]
        [Column(TypeName = "varchar(100)")]
        public string ImgProd { get; set; }

        //propriedade de navegação => relacionamento entre PRODUTO E VENDA
        public ICollection<Venda> Venda { get; set; }
    }
}
