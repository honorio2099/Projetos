using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PortalNoticias.Models;

namespace PortalNoticias.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index() //=> PARAMETROS na método significa que a VIEW enviou
        {
            return View(RepositorioNoticias.ListaNoticias); 
            //=> PARAMETROS no return VIEW() significa que a MODEL enviou
            //alguma informação para ser exibida na tela
        }

        public ActionResult Detalhes(int id) // o pedido de Cliente na VIEW que representa o id da noticia selecionada
        {
            //esta pesquisa acontece dentro da MODEL
            var noticia = RepositorioNoticias.ListaNoticias.FirstOrDefault(n => n.Id == id);
            //o método FIRSTORDEFAULT retorna somente 1 resposta

            return View(noticia);
            //estamos retornando para o cliente na VIEW a notícia que a MODEL encontrou
            //com o id que o Cliente escolheu na VIEW
        }

        public ActionResult Buscar(String texto) // o cliente irá pedir qual a notícia que deseja ler através de um trecho do título ou do conteúdo
        {
            //solicitação para a MODEL pesquisar o pedido do cliente
            var noticias = RepositorioNoticias.ListaNoticias.Where
                (n => n.Titulo.Contains(texto) || n.Conteudo.Contains(texto));
            //o método WHERE faz a pesquisa retornando 1 ou mais noticias

            return View(noticias);
            //retorna a resposta da MODEL para a VIEW
        }

        // precisamos cirar o método HTTP GET para página cadastro ser exibida para o cliente
        // OBS: NÕA É RESPONSÁVEL PELO CADASTRO!!!
        public ActionResult Cadastrar ()
        {
            return View();
        }
        /////////////////////////////////////////////////////////////////////////////////////////

        // criar um método Http GET igual o Http Post
        // este será responsável por insiri uma notícia na lista
        [HttpPost]
        public ActionResult Cadastrar(Noticia noticia)// recebendo objeto noticia digitado pelo usuário
        {
            // enviar para Model o objeto recebido por parâmetro
            RepositorioNoticias.InserirNoticias(noticia);
            // retornar para o cliente a VIEW
            return View();
        }

    }
}