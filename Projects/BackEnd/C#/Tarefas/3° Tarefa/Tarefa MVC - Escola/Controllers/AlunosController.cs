using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DicasTarefa.Models;

namespace DicasTarefa.Controllers
{
    public class AlunosController : Controller
    {
        // GET: Alunos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadAlunos()
        {
            return View(RepositorioAlunos.ListaAlunos);
        }

        public ActionResult Detalhes(int id) // o pedido de Cliente na VIEW que representa o id do Aluno selecionado
        {
            //esta pesquisa acontece dentro da MODEL
            var aluno = RepositorioAlunos.ListaAlunos.FirstOrDefault(A => A.IdAluno == id);
            //o método FIRSTORDEFAULT retorna somente 1 resposta

            return View(aluno);
            //estamos retornando para o cliente na VIEW o Aluno que a MODEL encontrou
            //com o id que o Cliente escolheu na VIEW
        }

        public ActionResult Buscar(String nomeAluno, String serieAluno)
        {
            var alunosSelecionados = RepositorioAlunos.ListaAlunos.Where
                (aluno => aluno.NomeAluno.Contains(nomeAluno) &&
                aluno.SerieAluno.Contains(serieAluno));
            return View(alunosSelecionados);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Alunos aluno)
        {
            RepositorioAlunos.InserirAlunos(aluno);
            return View();
        }


    }
}