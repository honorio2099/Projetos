using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tarefa_MVC_Core_CHAPELARIA.Models.CHAPELARIA_VIEW_MODEL
{
    public class Venda_ViewModel
    {
        // Venda -

        /*[Key]
        [Column("Id_vendas")]
        */
        [Display(Name = "Identificação da venda")]
        
        public int Id_vendas { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Favor informar o nome do Cliente")]
        public string Nomecliente { get; set; }

        [Display(Name = "Nome do Chapéu")]
        [Required(ErrorMessage = "Favor informar o nome do Chapéu")]
        public string Nome_chapeu { get; set; }

        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Favor informar a forma de Pagamento")]
        public string Nome_formapag { get; set; }

        [Display(Name = "Quantidade de Chapéus")]
        [Required(ErrorMessage = "Favor informar a Quantidade de Chapéus desejadas")]
        public int Qtd { get; set; }

        [Display(Name = "Total de Chapéus")]
        [Required(ErrorMessage = "Favor informar o Total da Venda")]
        public double Total { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Compra")]
        [Required(ErrorMessage = "Favor informar a Data da Compra")]
        public DateTime Data_compra { get; set; }

        // Chapéu   
        public int Id_hat { get; set; }
        public string Nome_Chapéu { get; set; }  
        public string Cor_Chapéu { get; set; }
        public int QtdAvailable { get; set; }
        public double Price { get; set; }

        ////////////////////////////////////////////

    }
}
