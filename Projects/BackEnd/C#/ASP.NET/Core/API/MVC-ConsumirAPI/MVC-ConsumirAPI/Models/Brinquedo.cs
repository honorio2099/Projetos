using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ConsumirAPI.Models
{
    public class Brinquedo
    {
        [Key]
        public int IDBrinquedo { get; set; }

        [Required(ErrorMessage = "Nome do Brinquedo Obrigatório!!!")]
        public string NomeBrinquedo { get; set; }

        [Required(ErrorMessage = "Fabricante do Brinquedo Obrigatório!!!")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Genero do Brinquedo Obrigatório!!!")]
        [StringLength(30, ErrorMessage = "até 30 caracteres permitidos!!!")]
        public string Genero { get; set; }

        [Range(0, 1000, ErrorMessage = "Estoque mínimo de 0 a 1000 unidades!!!")]
        public int Estoque { get; set; }
    }
}
