using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class Cliente
    {
        int idcli;
        string nomeCliente, rg, cpf;
        double rendamensal;

        public int Idcli { get => idcli; set => idcli = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public double Rendamensal { get => rendamensal; set => rendamensal = value; }
    }
}