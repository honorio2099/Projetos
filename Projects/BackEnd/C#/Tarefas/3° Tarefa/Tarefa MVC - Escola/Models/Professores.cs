using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DicasTarefa.Models
{
    public class Professores
    {
        DateTime datanascimento;
        int idProfessor, idade, experiencia;
        double salario;
        string nomeProfessor, rG, cPF, endereço, escolaridade, disciplinas, disponibilidade;


        [Display(Name = "Data de nascimento: ")]
        public DateTime DatanascimentoProfessor { get => datanascimento; set => datanascimento = value; }

        [Display(Name = "Id do Professor: ")]
        public int IdProfessor { get => idProfessor; set => idProfessor = value; }

        [Display(Name = "Tempo de Experiência do Professor: ")]
        public int Experiencia { get => experiencia; set => experiencia = value; } 

        [Display(Name = "Salário do Professor: ")]
        public double Salario { get => salario; set => salario = value; }

        [Display(Name = "Nome do Professor: ")]
        public string NomeProfessor { get => nomeProfessor; set => nomeProfessor = value; }

        [Display(Name = "RG do Professor: ")]
        public string RG { get => rG; set => rG = value; }

        [Display(Name = "CPF do Professor: ")]
        public string CPF { get => cPF; set => cPF = value; }

        [Display(Name = "Endereço do Professor: ")]
        public string Endereço { get => endereço; set => endereço = value; }

        [Display(Name = "Escolaridade do Professor: ")]
        public string Escolaridade { get => escolaridade; set => escolaridade = value; }

        [Display(Name = "Disciplinas do Professor: ")]
        public string Disciplinas { get => disciplinas; set => disciplinas = value; }

        [Display(Name = "Disponibilidade do Professor: ")]
        public string Disponibilidade { get => disponibilidade; set => disponibilidade = value; }

        [Display(Name = "Idade do Professor: ")]
        public int Idade { get => idade; set => idade = value; }
    }
}