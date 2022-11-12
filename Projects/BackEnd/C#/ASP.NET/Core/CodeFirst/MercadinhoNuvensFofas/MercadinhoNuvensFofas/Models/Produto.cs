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

        [Display(Name ="Nome do Produto")]
        [Column(TypeName ="varchar(50)")]
        [Required]
        public string NomeProd { get; set; }

        [Display(Name ="Estoque")]
        public int QtdDispProd { get; set; }

        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        public double PrecoProd 
        { 
            get
            {
                return PrecoProd;
            } 
            set
            {
                string pricestr = PrecoProd.ToString();
                PrecoProd == Convert.ToDouble(pricestr)
            } 
        }

        [Display(Name = "Imagem")]
        [Column(TypeName = "varchar(50)")]
        public string imgProd { get; set; }


        public ICollection<Venda> Vendas { get; set; }
    }
}
