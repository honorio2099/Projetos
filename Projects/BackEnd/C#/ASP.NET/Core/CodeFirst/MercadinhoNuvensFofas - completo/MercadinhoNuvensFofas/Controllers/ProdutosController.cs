using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadinhoNuvensFofas.Data;
using MercadinhoNuvensFofas.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MercadinhoNuvensFofas.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IWebHostEnvironment _appEnvironment;

        public ProdutosController(ApplicationContext context, IWebHostEnvironment env)
        {
            _context = context;
            _appEnvironment = env;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {

            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("NomeProd,QtdDispProd,PrecoProd")] Produto produto,
            IFormFile fotoAnexo)
        {
            if (ModelState.IsValid)
            {
                //criar a variável para armazenar o URL da TABLE
                String urlBD;

                if (fotoAnexo != null) // significa que o usuário adicionou a FOTO
                {
                    //obtém o endereço/caminho físico da pasta wwwroot
                    var caminho_WebRoot = _appEnvironment.WebRootPath;

                    //montando o caminho aonde será salvo o arquivo 
                    var caminhoDestinoArquivo = caminho_WebRoot + "\\IMG\\" + fotoAnexo.FileName;

                    //copiar (UPLOAD) da foto para a pasta de destino
                    using (var stream = new FileStream(caminhoDestinoArquivo, FileMode.Create))
                    {
                        await fotoAnexo.CopyToAsync(stream);
                    }

                    urlBD = "~/IMG/"+fotoAnexo.FileName;
                }
                else //significa que o usuário NÃO adicionou a FOTO
                {
                    urlBD = "~/IMG/sem-imagem.jfif";
                }

                // adicionar ao objeto PRODUTO a url da foto escolhida
                produto.ImgProd = urlBD;

                // adição das informações na TABLE
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProd,NomeProd,QtdDispProd,PrecoProd,ImgProd")] Produto produto,
            IFormFile novaFoto)
        {
            if (id != produto.IdProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string urlBD;

                if (novaFoto != null)
                {
                    //obtém o endereço/caminho físico da pasta wwwroot
                    var caminho_WebRoot = _appEnvironment.WebRootPath;

                    //montando o caminho aonde será salvo o arquivo 
                    var caminhoDestinoArquivo = caminho_WebRoot + "\\IMG\\" + novaFoto.FileName;

                    //copiar (UPLOAD) da foto para a pasta de destino
                    using (var stream = new FileStream(caminhoDestinoArquivo, FileMode.Create))
                    {
                        await novaFoto.CopyToAsync(stream);
                    }

                    urlBD = "~/IMG/"+novaFoto.FileName;
                }
                else
                {
                    urlBD = produto.ImgProd;
                }

                produto.ImgProd = urlBD;

                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.IdProd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProd == id);
        }
    }
}
