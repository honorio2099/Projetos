using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using LoginComSession.Data;
using LoginComSession.Models;

namespace LoginComSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            // buscar o usuário que tenha o login e a senha ao mesmo tempo
            var usuario = _context.Usuarios.FirstOrDefault(
                u => u.LoginUsu == login &&
                u.SenhaUsu == senha);

            //verificar se foi encontrado o usuário com o login e a senha fornecidos no HTML
            if (usuario != null)
            {
                HttpContext.Session.SetString("loginUsuario", usuario.NomeUsu);
                HttpContext.Session.SetString("idUsuario", usuario.IdUsu.ToString());

                if (usuario.TipoUsu == "ADM")
                {
                    HttpContext.Session.SetString("TipoUsuario", usuario.TipoUsu);
                    return RedirectToAction("IndexADM", "Usuario");
                }

                if (usuario.TipoUsu == "FUNC")
                {
                    HttpContext.Session.SetString("TipoUsuario", usuario.TipoUsu);
                    return RedirectToAction("IndexADM", "Usuario");
                }

                if (usuario.TipoUsu == "CLI")
                {
                    HttpContext.Session.SetString("TipoUsuario", usuario.TipoUsu);
                    return RedirectToAction("IndexADM", "Usuario");
                }

                return RedirectToAction(nameof(Success));
            }
            else
            {
                ViewBag.Error = "Usuário não cadastrado!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Success()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("loginUsuario"))) 
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();               
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loginUsuario"); // remove uma session específica

            //HttpContext.Session.Clear(); // remove todas as sessões criadas

            return RedirectToAction(nameof(Index));
        }
    }
}
