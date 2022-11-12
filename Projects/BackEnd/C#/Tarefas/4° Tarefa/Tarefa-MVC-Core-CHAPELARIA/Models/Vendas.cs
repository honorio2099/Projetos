using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tarefa_MVC_Core_CHAPELARIA.Models
{
    public class Vendas
    {
        [Key]
        [Column("Id_vendas")]
        [Display(Name = "Identificação da venda")]
        public int Id_vendas { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Favor informar o nome do Cliente")]
        public string Nomecliente { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nome do Chapéu")]
        [Required(ErrorMessage = "Favor informar o nome do Chapéu")]
        public string Nome_chapeu { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Favor informar a forma de Pagamento")]
        public string Nome_formapag { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Quantidade de Chapéus")]
        [Required(ErrorMessage = "Favor informar a Quantidade de Chapéus desejadas")]
        public int Qtd { get; set; }

        [Column(TypeName = "float")]
        [Display(Name = "Total de Chapéus")]
        [Required(ErrorMessage = "Favor informar o Total da Venda")]
        public double Total { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")] // esse date possivelmente dará problema
        [Display(Name = "Data da Compra")]
        [Required(ErrorMessage = "Favor informar a Data da Compra")]
        public DateTime Data_compra { get; set; }

    }
}

