using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadinhoNuvensFofas.Data;
using MercadinhoNuvensFofas.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MercadinhoNuvensFofas.Controllers
{
    public class BebidasController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public BebidasController(ApplicationContext context, IWebHostEnvironment env)
        {
            _context = context;
            _appEnvironment = env;
        }

        // GET: Bebidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bebidas.ToListAsync());
        }

        // GET: Bebidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas
                .FirstOrDefaultAsync(m => m.IdBeb == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // GET: Bebidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bebidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("NomeBeb,QtdDispBeb,PrecoBeb")] Bebida bebida, IFormFile fotoAnexo)
        {
            if (ModelState.IsValid)
            {
                string urlBD;

                if (fotoAnexo != null)
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

                    urlBD = "~/IMG/" + fotoAnexo.FileName;
                }
                else
                {
                    urlBD = "~/IMG/sem-imagem.jfif";
                }

                bebida.ImgBeb = urlBD;

                _context.Add(bebida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bebida);
        }

        // GET: Bebidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("IdBeb,NomeBeb,QtdDispBeb,PrecoBeb,ImgBeb")] Bebida bebida,
            IFormFile novaFoto)
        {
            if (id != bebida.IdBeb)
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

                    urlBD = "~/IMG/" + novaFoto.FileName;
                }
                else
                {
                    urlBD = bebida.ImgBeb;
                }

                bebida.ImgBeb = urlBD;

                try
                {
                    _context.Update(bebida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidaExists(bebida.IdBeb))
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
            return View(bebida);
        }

        // GET: Bebidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas
                .FirstOrDefaultAsync(m => m.IdBeb == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidaExists(int id)
        {
            return _context.Bebidas.Any(e => e.IdBeb == id);
        }
    }
}
