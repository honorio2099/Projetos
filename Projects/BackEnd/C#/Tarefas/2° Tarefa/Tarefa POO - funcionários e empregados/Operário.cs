using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Operário: Empregado
    {
        double valorProdução, comissão;

        public double ValorProdução { get => valorProdução; set => valorProdução = value; }
        public double Comissão { get => comissão; set => comissão = value; }

        // erro no Operário também (provavelmente relacionado ao construtor da classe Empregado)?
        public Operário(string nome,
        int idade, double salárioBase, double impostoDeRenda,
        int numSeção, double valorProdução, double comissão)
        {
            Nome = nome;
            Idade = idade;
            SalárioBase = salárioBase;
            ImpostoDeRenda = impostoDeRenda;
            NumSeção = numSeção;
            //
            ValorProdução = valorProdução;
            Comissão = comissão;
        }

        public double calcularSal()
        {
            // verificar essa conta aqui
            double resto = SalárioBase * ImpostoDeRenda;
            Comissão = (valorProdução * Comissão) / 100;
            SalárioBase = SalárioBase - resto;
            double novoSalário = SalárioBase + Comissão;
            return novoSalário;
        }
    }
}
