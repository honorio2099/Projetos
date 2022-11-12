using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Fornecedor: Pessoa
    {
        double crédito;
        double valorDivida;

        public double Crédito { get => crédito; set => crédito = value; }
        public double ValorDivida { get => valorDivida; set => valorDivida = value; }

        public Fornecedor() { }
        public Fornecedor (string nome,
        int idade, double crédito,
        double valorDivida)
        {
            Nome = nome;
            Idade = idade;
            Crédito = crédito;
            ValorDivida = valorDivida;
        }
        public double ObterValor ()
        {
            double diferença = crédito - valorDivida;
            return diferença;
        }
      
    }
}
