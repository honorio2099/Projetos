using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNoticias.Models
{
    public class Noticia
    {
        int id;
        string titulo, autor, conteudo;
        DateTime data;
                
        [Display (Name = "Id da Noticía: ")]
        [Required (ErrorMessage = "Campo ID Obrigatório!!!")]
        public int Id { get => id; set => id = value; }

        [Display(Name = "Título da Noticía: ")]
        [Required(ErrorMessage = "Campo Título Obrigatório!!!")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O Título deve ser entre 4 ou 10 Caracteres!!!")]
        public string Titulo { get => titulo; set => titulo = value; }

        [Display(Name = "Autor da Noticía: ")]
        [Required(ErrorMessage = "Campo Autor Obrigatório!!!")]
        public string Autor { get => autor; set => autor = value; }

        [Display(Name = "Conteúdo da Noticía: ")]
        [Required(ErrorMessage = "Campo Conteúdo Obrigatório!!!")]
        public string Conteudo { get => conteudo; set => conteudo = value; }

        [Display(Name = "Data de Publicação: ")]
        [Required(ErrorMessage = "Campo Data Obrigatório!!!")]
        public DateTime Data { get => data; set => data = value; }
    }
}