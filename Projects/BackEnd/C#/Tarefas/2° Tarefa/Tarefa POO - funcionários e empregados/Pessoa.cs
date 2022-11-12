using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Pessoa
    {
        string nome;
        int idade;
        bool test;

        public string Nome { get => nome; set => nome = value; }
        public int Idade { get => idade; set => idade = value; }
        public bool Test { get => test; set => test = value; }

        public void Niver()
        {
            Idade = Idade + 1;
        }
    }
}
