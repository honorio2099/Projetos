using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Empregado: Pessoa
    {
        int numSeção;
        double salárioBase, impostoDeRenda;

        public int NumSeção { get => numSeção; set => numSeção = value; }
        public double SalárioBase 
        { get => salárioBase;
            set
            {
                if (value < 1903.99 )
                {
                    ImpostoDeRenda = 0;
                }
                if (value > 1904 && value < 2826.65)
                {
                    ImpostoDeRenda = 0.7;
                }
                if (value > 2826.66 && value < 3751.05)
                {
                    ImpostoDeRenda = 0.15;
                }
                if (value > 3751.05 && value < 4664.68)
                {
                    ImpostoDeRenda = 0.22;
                }
                if (value > 4664.68)
                {
                    ImpostoDeRenda = 0.27; 
                }
            } 
        }
        public double ImpostoDeRenda { get => impostoDeRenda; set => impostoDeRenda = value; }

        public Empregado () { }

        public Empregado(string nome,
        int idade, double salárioBase, double impostoDeRenda,
        int numSeção)
        {
            Nome = nome;
            Idade = idade;
            SalárioBase = salárioBase;
            ImpostoDeRenda = impostoDeRenda;
            NumSeção = numSeção;
        }

        public double calcularSal ()
        {
            double resto = SalárioBase * ImpostoDeRenda;
            double novoSalário = SalárioBase - resto;
            return novoSalário;
        }
    }
}
