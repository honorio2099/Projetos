using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class RepositorioClientes
    {
        static List<Cliente> listaClientes = new List<Cliente>();

        public static List<Cliente> ListaClientes
        {
            get
            {
                if (listaClientes.Count == 0)
                {
                    criarListaClientes();
                }
                return listaClientes;
                } 
        }

        public static void InserirClientes(Cliente cli)
        {
            ListaClientes.Add(cli);
        }

        private static void criarListaClientes()
        {
            listaClientes.Add(
                new Cliente
                {
                    Idcli = 1,
                    NomeCliente = "Heitor Davi Bernardes",
                    Rg = "46.640.403-7",  
                    Cpf = "646.234.640-08",  
                    Rendamensal = 2350.78
                }
                );

            listaClientes.Add(
                new Cliente
                {
                    Idcli = 2,
                    NomeCliente = "Augusto Benício Lucca Duarte",
                    Rg = "40.150.179-6",
                    Cpf = "939.825.452-26",
                    Rendamensal = 5600
                }
                );

            listaClientes.Add(
                new Cliente
                {
                    Idcli = 3,
                    NomeCliente = "Maya Daniela Tânia da Luz",
                    Rg = "15.255.038-0",
                    Cpf = "751.877.515-81",
                    Rendamensal = 3200
                }
                );

            listaClientes.Add(
                new Cliente
                {
                    Idcli = 4,
                    NomeCliente = "Emilly Gabrielly Caldeira",
                    Rg = "33.829.409-0",
                    Cpf = "727.268.880-70",
                    Rendamensal = 2400
                }
                );

            listaClientes.Add(
                new Cliente
                {
                    Idcli = 5,
                    NomeCliente = "Pietro Marcos Vinicius Rodrigo Baptista",
                    Rg = "28.142.471-8",
                    Cpf = "638.044.840-34",
                    Rendamensal = 2900
                }
                );
        }
        //set => listaClientes = value; 
    }
}