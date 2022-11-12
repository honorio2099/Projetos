using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class RepositorioBrinquedos
    {
        static List<Brinquedos> listaBrinquedos = new List<Brinquedos>();

        public static List<Brinquedos> ListaBrinquedos 
        { 
            get
            {
                if (listaBrinquedos.Count == 0)
                {
                    criarlistaBrinquedos();
                }
                return listaBrinquedos;
                // Ou pode ser feito assim também -
                // ListaBrinquedos.Clear();
                // criarlistaBrinquedos();
                // return listaBrinquedos;
            }
            // set => listaBrinquedos = value; 
        }

        public static void InserirBrinquedos(Brinquedos brinq)
        {
            ListaBrinquedos.Add(brinq);

        }

        private static void criarlistaBrinquedos()
        {
            ListaBrinquedos.Add
                (
                new Brinquedos
                {
                    IdBriquedo = 1,
                    Nome = "Bola de futebol",
                    Fabricante = "Penalty",
                    FaixaEtaria = "Acima de 2 Anos",
                    Preco = 23.45
                }
                );

            listaBrinquedos.Add
                (
                new Brinquedos
                {
                    IdBriquedo = 2,
                    Nome = "Carrinho Hot Wheels",
                    Fabricante = "Mattel",
                    FaixaEtaria = "Acima de 3 Anos",
                    Preco = 23.45
                }
                );

            listaBrinquedos.Add
                (
                new Brinquedos
                {
                    IdBriquedo = 3,
                    Nome = "Boneca Barbie",
                    Fabricante = "Estrela",
                    FaixaEtaria = "Acima de 3 Anos",
                    Preco = 99.99
                }
                );

            listaBrinquedos.Add
                (
                new Brinquedos
                {
                    IdBriquedo = 4,
                    Nome = "Banco Imobiliário",
                    Fabricante = "Grow",
                    FaixaEtaria = "Acima de 8 Anos",
                    Preco = 177.99
                }
                );

            listaBrinquedos.Add
                (
                new Brinquedos
                {
                    IdBriquedo = 5,
                    Nome = "Jogo da Vida",
                    Fabricante = "Grow",
                    FaixaEtaria = "Acima de 12 Anos",
                    Preco = 224.45
                }
                );

        }
    }
}