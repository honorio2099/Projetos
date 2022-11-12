using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ConsumirAPI.Models;
using Newtonsoft.Json;

namespace MVC_ConsumirAPI.Controllers
{
    public class BrinquedosController : Controller
    {
        // variável/caminho para chegar até a rota da API
        private readonly string urlAPI = "http://localhost:5000/Brinquedos";

        // irá acionar um método HTTPGET
        public async Task<IActionResult> Index()
        {
            //lista de brinquedos
            List<Brinquedo> listbrinquedos = new List<Brinquedo>();

            //instância de cliente para o protocolo HTTP
            using (var httpClient = new HttpClient())
            {
                // instância de resposta dá o endereço da API
                using (var response = await httpClient.GetAsync(urlAPI))
                {
                    var respostaApi = await response.Content.ReadAsStringAsync();
                    listbrinquedos = JsonConvert.DeserializeObject<List<Brinquedo>>(respostaApi);
                }
            }
            return View(listbrinquedos);
        }
    }
}
