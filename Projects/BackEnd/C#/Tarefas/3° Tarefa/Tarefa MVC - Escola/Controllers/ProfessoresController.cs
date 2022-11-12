using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DicasTarefa.Models;

namespace DicasTarefa.Controllers
{
    public class ProfessoresController : Controller
    {
        // GET: Professores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadProfessores()
        {
            return View(RepositorioProfessores.ListaProfessores);
        }

        public ActionResult Detalhes(int id) // o pedido de Cliente na VIEW que representa o id do professor selecionado
        {
            //esta pesquisa acontece dentro da MODEL
            var professor = RepositorioProfessores.ListaProfessores.FirstOrDefault(P => P.IdProfessor == id);
            //o método FIRSTORDEFAULT retorna somente 1 resposta

            return View(professor);
            //estamos retornando para o cliente na VIEW o professor que a MODEL encontrou
            //com o id que o Cliente escolheu na VIEW
        }

        public ActionResult Buscar(String nomeProfessor, String disciplinas)
        {
            var ProfessoresSelecionados = RepositorioProfessores.ListaProfessores.Where
                (professor => professor.NomeProfessor.Contains(nomeProfessor) &&
                professor.Disciplinas.Contains(disciplinas));
            return View(ProfessoresSelecionados);
        }


        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Professores professor)
        {
            RepositorioProfessores.InserirProfessores(professor);
            return View();
        }

    }
}