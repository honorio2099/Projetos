
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_MVC_Core_CHAPELARIA.Models.CHAPELARIA_VIEW_MODEL
{
    public class RepositorioChapeu
    {

        public static List<Chapéus> getListaChapéus()
        {
            // este método será utilizado para carregar o DropDownList e retornar o chapéus selecionado
            var listaChapeus = new List<Chapéus>()
            {
                new Chapéus()
                {
                    Id_hat = 1,
                    Nome_Chapéu = "Masculino – com Abas Curtas",
                    Cor_Chapéu = "Preto",
                    QtdAvailable = 23,
                    Price = 45.60
                },

                new Chapéus()
                {
                    Id_hat = 2,
                    Nome_Chapéu = "Feminino – sem Abas",
                    Cor_Chapéu = "Marrom",
                    QtdAvailable = 12,
                    Price = 39.50
                },

                new Chapéus()
                {
                    Id_hat = 3,
                    Nome_Chapéu = "Boné",
                    Cor_Chapéu = "Azul",
                    QtdAvailable = 5,
                    Price = 75.00
                }
            };

            return listaChapeus;
        }
    }
}
