using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefa_MVC_Core_Agência_de_Empregos.Models
{
    public class Curriculo
    {
        int id_cur;
        string nome_candidato, rg_candidato, cpf_candidato, estado_civil, escolaridade , ingles_nivel, espanhol_nivel, frances_nivel;
        double pretensao_sal;


        [Key]
        [Column("Id_cur")]
        [Display(Name = "Identificação do Currículo")]
        // [Required(ErrorMessage = "")]
        // [StringLength(10, MinimumLength = 4, ErrorMessage = "O  deve ser entre 4 ou 10 Caracteres!!!")]
        public int Id_cur { get => id_cur; set => id_cur = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nível de Ingles")]
        [Required(ErrorMessage = "Favor informar o nível de fluência/experiência na lingua Inglesa")]
        public string Ingles_nivel { get => ingles_nivel; set => ingles_nivel = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nível de Espanhol")]
        [Required(ErrorMessage = "Favor informar o nível de fluência/experiência em Espanhol")]
        public string Espanhol_nivel { get => espanhol_nivel; set => espanhol_nivel = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nível de Francês")]
        [Required(ErrorMessage = "Favor informar o nível de fluência/experiência em Francês")]
        public string Frances_nivel { get => frances_nivel; set => frances_nivel = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nome do candidato")]
        [Required(ErrorMessage = "Favor informar o nome do candidato a vaga")]
        public string Nome_candidato { get => nome_candidato; set => nome_candidato = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Rg do candidato")]
        [Required(ErrorMessage = "Favor informar o Rg do candidato a vaga")]
        public string Rg_candidato { get => rg_candidato; set => rg_candidato = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Cpf do candidato")]
        [Required(ErrorMessage = "Favor informar o Cpf do candidato a vaga")]

        public string Cpf_candidato { get => cpf_candidato; set => cpf_candidato = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Estado civil do candidato")]
        [Required(ErrorMessage = "Favor informar o Estado civil do candidato a vaga")]
        public string Estado_civil { get => estado_civil; set => estado_civil = value; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Escolaridade do candidato")]
        [Required(ErrorMessage = "Favor informar a Escolaridade do candidato a vaga")]
        public string Escolaridade { get => escolaridade; set => escolaridade = value; }

        [Column(TypeName = "float")]
        [Display(Name = "Pretensão salarial do candidato R$")]
        [Required(ErrorMessage = "Favor informar a Pretensão salarial do candidato a vaga")]
        public double Pretensao_sal { get => pretensao_sal; set => pretensao_sal = value; }
    }
}
