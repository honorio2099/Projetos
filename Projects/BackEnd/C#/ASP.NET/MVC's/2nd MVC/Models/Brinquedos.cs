using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class Brinquedos
    {
        int idBriquedo;
        string nome, faixaEtaria, fabricante;
        double preco;

        public int IdBriquedo { get => idBriquedo; set => idBriquedo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string FaixaEtaria { get => faixaEtaria; set => faixaEtaria = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }
        public double Preco { get => preco; set => preco = value; }
    }
}