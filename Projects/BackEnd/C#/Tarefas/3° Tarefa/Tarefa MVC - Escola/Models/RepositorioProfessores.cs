using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DicasTarefa.Models
{
    public class RepositorioProfessores
    {
        static List<Professores> listaProfessores = new List<Professores>();

        public static List<Professores> ListaProfessores
        {
            get
            {
                if (listaProfessores.Count == 0)
                {
                    criarListaProfessores();
                }

                return listaProfessores;
            }

            // set => listaAlunos = value; 
        }

        public static void InserirProfessores(Professores professor)
        {
            calcularIdade(professor);
            if (listaProfessores.Count == 0)
            {
                criarListaProfessores();
            }
            listaProfessores.Add(professor);
        }

        private static void calcularIdade(Professores professor)
        {
            int anoAtual, anoNascimento;
            anoAtual = DateTime.Now.Year;
            anoNascimento = professor.DatanascimentoProfessor.Year;
            professor.Idade = anoAtual - anoNascimento;
        }

        private static void criarListaProfessores()
        {
            listaProfessores = new List<Professores>();

            listaProfessores.Add
                (
                new Professores
                {
                    DatanascimentoProfessor = Convert.ToDateTime("24/02/1978"),
                    IdProfessor = 1,
                    Idade = 44,
                    Experiencia = 15,
                    NomeProfessor = "José Josefino Josefado",
                    Salario = 1650,
                    Escolaridade = "Completa", // mestrado, doutorado ou fundamental e médio??
                    Disciplinas = "História", 
                    Disponibilidade = "Disponível",
                    RG = "26.330.300-7",
                    CPF = "229.409.062-46",
                    Endereço = "CEP: 69088-751, Número: 602, Rua: Rua Ipê Roxo, Bairro: Jorge Teixeira, Cidade: Manaus, Estado: AM"
                }
                );
        }
    }
}