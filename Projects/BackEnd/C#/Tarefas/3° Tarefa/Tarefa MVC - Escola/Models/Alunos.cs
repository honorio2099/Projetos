using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DicasTarefa.Models
{
    public class Alunos
    {
        DateTime dataNascimentoaluno;
        int idAluno, idade;
        double valorMensal;
        string nomeAluno, nomePai, nomeMae, responsavel, rgResponsavel, cpfResponsavel, fullAddress, serieAluno;

        [Display (Name = "Data de nascimento: ")]
        public DateTime DataNascimentoaluno { get => dataNascimentoaluno; set => dataNascimentoaluno = value; }

        [Display(Name = "Idade do Aluno: ")]
        public int Idade { get => idade; set => idade = value; }

        [Display(Name = "Nome do Aluno: ")]
        public string NomeAluno { get => nomeAluno; set => nomeAluno = value; }

        [Display(Name = "Série do Aluno: ")]
        public string SerieAluno { get => serieAluno; set => serieAluno = value; }

        [Display(Name = "ID do Aluno: ")]
        public int IdAluno { get => idAluno; set => idAluno = value; }

        [Display(Name = "Valor Mensal: ")]
        public double ValorMensal { get => valorMensal; set => valorMensal = value; }

        [Display(Name = "Pai do Aluno: ")]
        public string NomePai { get => nomePai; set => nomePai = value; }

        [Display(Name = "Mãe do Aluno: ")]
        public string NomeMae { get => nomeMae; set => nomeMae = value; }

        [Display(Name = "Responsável do Aluno: ")]
        public string Responsavel { get => responsavel; set => responsavel = value; }

        [Display(Name = "RG - Responsável: ")]
        public string RgResponsavel { get => rgResponsavel; set => rgResponsavel = value; }

        [Display(Name = "CPF - Responsável: ")]
        public string CpfResponsavel { get => cpfResponsavel; set => cpfResponsavel = value; }

        [Display(Name = "Endereço do Aluno: ")]
        public string FullAddress { get => fullAddress; set => fullAddress = value; }
    }
}