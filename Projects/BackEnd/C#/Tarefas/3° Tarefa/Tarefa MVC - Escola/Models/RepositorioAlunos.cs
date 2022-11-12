using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DicasTarefa.Models
{
    public class RepositorioAlunos
    {
        static List<Alunos> listaAlunos = new List<Alunos>();

        public static List<Alunos> ListaAlunos 
        { 
          get
            {
                if (listaAlunos.Count == 0)
                {
                    criarListaAlunos();
                }

                return listaAlunos;
            } 

          // set => listaAlunos = value; 
        }

        public static void InserirAlunos(Alunos aluno)
        {
            calcularIdade(aluno);
            if (listaAlunos.Count == 0) 
            {
                criarListaAlunos();     
            }
            listaAlunos.Add(aluno);
        }

        private static void calcularIdade(Alunos aluno)
        {
            int anoAtual, anoNascimento;
            anoAtual = DateTime.Now.Year;
            anoNascimento = aluno.DataNascimentoaluno.Year;
            aluno.Idade = anoAtual - anoNascimento;
        }

        private static void criarListaAlunos()
        {
            listaAlunos = new List<Alunos>();

            listaAlunos.Add
                (
                new Alunos
                {
                    DataNascimentoaluno = Convert.ToDateTime("17/06/2012"),
                    IdAluno = 1,
                    Idade = 10,
                    ValorMensal = 1400,
                    NomeAluno = "Rodrigo",
                    NomePai = "Carlos Roberto",
                    NomeMae = "Luciene",
                    Responsavel = "Carlos Roberto e Luciene",
                    RgResponsavel = "32.366.966-9",
                    CpfResponsavel = "427.801.560-74",
                    FullAddress = "CEP: 19026-885, Número: 639, Rua: Jose Vitorio Sylla, Bairro: Jardim Panorâmico, Cidade: Presidente Prudente, Estado: SP",
                    SerieAluno = "5º Ano"
                }
                );
        }
                
    }
}