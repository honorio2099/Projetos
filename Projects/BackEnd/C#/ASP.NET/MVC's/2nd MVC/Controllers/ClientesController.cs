using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _2nd_MVC.Models;


namespace _2nd_MVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View(RepositorioClientes.ListaClientes);
        }

        public ActionResult Details(int id)
        {
            var cliente = RepositorioClientes.ListaClientes.FirstOrDefault
                (cli => cli.Idcli == id);
            return View(cliente);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cli)
        {
            // enviar o objeto para a MODEL RepositórioClientes
            RepositorioClientes.InserirClientes(cli);
            return View();
        }
    }
}