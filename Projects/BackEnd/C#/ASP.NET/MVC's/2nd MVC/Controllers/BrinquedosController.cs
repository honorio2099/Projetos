using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _2nd_MVC.Models;

namespace _2nd_MVC.Controllers
{
    public class BrinquedosController : Controller
    {
        // GET: Brinquedos
        public ActionResult Index()
        {
            return View(RepositorioBrinquedos.ListaBrinquedos);
        }

        public ActionResult Details(int id) // recebendo da view o Id do Brinquedo
        {
            // Enviar para a Model buscar o Brinquedo Selecionado
            var Brinquedo = RepositorioBrinquedos.ListaBrinquedos.FirstOrDefault(brinq => brinq.IdBriquedo == id);
            // a MODEL vai enviar para o VIEW o brinquedo
            return View(Brinquedo);
        }

        // método GET que irá abrir a tela cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }
        //////////////////////////////////////////////////////////////////
        

        // método POST que irá enviar as informações para o servidor
        [HttpPost]
        public ActionResult Cadastrar(Brinquedos brinq)
        {
            // enviar o objeto para a MODEL RepositórioBrinquedos
            RepositorioBrinquedos.InserirBrinquedos(brinq);
            return View();
        }
        /////////////////////////////////////////////////////////////////////
        // usar RedirectToRouteResult no lugar de ActionResult e no return //
        // para retornar para outra tela(View) após um método e usar dentro /
        // do parênteses com aspas o endereço a ser adicionado //////////////
        /////////////////////////////////////////////////////////////////////
    }
}