using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _2nd_MVC.Models;


namespace _2nd_MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET: Funcionarios
        public ActionResult Index()
        {
            return View(RepositorioFuncionarios.ListaFuncionarios);
        }

        public ActionResult Details(int id)
        {
            var funcionario = RepositorioFuncionarios.ListaFuncionarios.FirstOrDefault
                (func => func.IdFunc == id);
            return View(funcionario); 
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionarios func)
        {
            // enviar o objeto para a MODEL RepositórioClientes
            RepositorioFuncionarios.InserirFunc(func);
            return View();
        }

    }
    }
