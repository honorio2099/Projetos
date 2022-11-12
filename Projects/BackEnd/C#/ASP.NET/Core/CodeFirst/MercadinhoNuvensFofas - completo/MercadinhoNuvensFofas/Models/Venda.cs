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

        [Display(Name ="Nome do Cliente")]
        [Column(TypeName ="varchar(100)")]
        public string NomeCliente { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("Produto")]
        public int IdProd { get; set; }
        //propriedade de navegação => relacionamento entre VENDAS e PRODUTO 1-n
        public Produto Produto { get; set; }
        /////////////////////////////////////////////////////////////////

        [Display(Name = "Bebida")]
        [ForeignKey("Bebida")]
        public int IdBeb { get; set; }
        //propriedade de navegação => relacionamento entre VENDAS e BEBIDA 1-n
        public Bebida Bebida { get; set; }
        //////////////////////////////////////////////////////////////////

        [Display(Name = "Forma de Entrega")]
        [ForeignKey("FormaEntrega")]
        public int IdForma { get; set; }
        //propriedade de navegação => relacionamento entre VENDAS e FORMA DE ENTREGA 1-n
        public FormaEntrega FormaEntrega { get; set; }
        //////////////////////////////////////////////////////////////////

        [Display(Name = "Data da Compra")]
        [Column(TypeName = "datetime")] // este item é para versões anteriores 
        [DataType(DataType.Date)]
        public DateTime DataCompra { get; set; }

        [Display(Name = "Qtd de Produto")]
        public int QtdProd { get; set; }

        [Display(Name = "Qtd de Bebida")]
        public int QtdBeb { get; set; }

        [Display(Name = "Total a Pagar")]
        public double TotalPagar { get; set; }
    }
}
