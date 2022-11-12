using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }

        [Display(Name = "Nome de Cliente")]
        public string NomeCliente { get; set; }

        // Relacionamento entre Vendas e Produto

        [Display(Name = "Produtos")]
        [ForeignKey("Produto")]
        public int IdProp { get; set; }
        public Produto Produto { get; set; }
        ///////////////////////////////////////////////

        // Relacionamento entre Vendas e Bebida

        [Display(Name = "Bebidas")]
        [ForeignKey("Bebida")]
        public int IdBeb { get; set; }
        public Bebida Bebida { get; set; }
        ///////////////////////////////////////////////

        [Display(Name = "Forma de Entrega")]
        [ForeignKey("FormaEntrega")]
        public int IdForma { get; set; }
        public FormaEntrega FormaEntrega { get; set; }
        ///////////////////////////////////////////////

        [Display(Name = "Quantidade de Produtos")]
        public int QTDprod { get; set; }

        [Display(Name = "Quantidade de Bebidas")]
        public int QTDBeb { get; set; }

        [Display(Name = "Data da Compra")]
        public DateTime DataCompra { get; set; }
    }
}
