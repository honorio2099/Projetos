using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class RepositorioFuncionarios
    {
        static List<Funcionarios> listaFuncionarios = new List<Funcionarios>();

        public static List<Funcionarios> ListaFuncionarios
        {
            get
            {
                if (listaFuncionarios.Count == 0)
                {
                    Criarlistafuncionarios();
                }
                return listaFuncionarios;
            }
        }

        public static void InserirFunc (Funcionarios func)
        {
            listaFuncionarios.Add(func);
        }


        private static void Criarlistafuncionarios()
        {
            listaFuncionarios.Add(
                new Funcionarios
                {
                    IdFunc = 1,
                    FuncNome = "Ana Simone Martins",
                    FuncRg = "12.861.631-3",
                    FuncCpf = "326.791.267-93",
                    FuncSalario = 2300
                }
                );

            listaFuncionarios.Add(
               new Funcionarios
               {
                   IdFunc = 2,
                   FuncNome = "Thomas Levi Severino Martins",
                   FuncRg = "33.591.837-2",
                   FuncCpf = "534.216.989-53",
                   FuncSalario = 2680.99

               }
               );

            listaFuncionarios.Add(
               new Funcionarios
               {
                   IdFunc = 3,
                   FuncNome = "Luciana Renata Valentina de Paula",
                   FuncRg = "11.653.821-1",
                   FuncCpf = "998.535.581-49",
                   FuncSalario = 4800.57

               }
               );

            listaFuncionarios.Add(
               new Funcionarios
               {
                   IdFunc = 4,
                   FuncNome = "Sérgio Ruan Bryan Fogaça",
                   FuncRg = "25.617.935-9",
                   FuncCpf = "593.458.243-75",
                   FuncSalario = 3320.35

               }
               );

            listaFuncionarios.Add(
               new Funcionarios
               {
                   IdFunc = 5,
                   FuncNome = "Emanuel Gabriel Filipe da Rocha",
                   FuncRg = "47.074.051-6",
                   FuncCpf = "430.282.665-71",
                   FuncSalario = 1900.99

               }
               );

        }


        //set => listaFuncionarios = value; 
    }
}