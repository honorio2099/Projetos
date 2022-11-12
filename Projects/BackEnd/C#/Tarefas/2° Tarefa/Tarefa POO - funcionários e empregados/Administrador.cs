using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Administrador: Empregado
    {
        double ajudasCusto;
        public double AjudasCusto { get => ajudasCusto; set => ajudasCusto = value; }

        public Administrador() { }
        public Administrador(string nome,
        int idade, double salárioBase, double impostoDeRenda,
        int numSeção, double AjudasCusto)
        {
            Nome = nome;
            Idade = idade;
            SalárioBase = salárioBase;
            ImpostoDeRenda = impostoDeRenda;
            NumSeção = numSeção;
            //
            ajudasCusto = AjudasCusto;
        }

        public double calcularSal()
        {
            double resto = SalárioBase * ImpostoDeRenda;
            SalárioBase = SalárioBase - resto;
            double novoSalário = SalárioBase + ajudasCusto;
            return novoSalário;
        }

    }
}
