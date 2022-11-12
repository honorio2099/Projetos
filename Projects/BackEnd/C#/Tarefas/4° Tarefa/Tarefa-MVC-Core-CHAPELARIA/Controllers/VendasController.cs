using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarefa_MVC_Core_CHAPELARIA.Data;
using Tarefa_MVC_Core_CHAPELARIA.Models;
using Tarefa_MVC_Core_CHAPELARIA.Models.CHAPELARIA_VIEW_MODEL;

namespace Tarefa_MVC_Core_CHAPELARIA.Controllers
{
    public class VendasController : Controller
    {

        private readonly ApplicationContext _context;
        private Chapéus chapéus = new Chapéus();
        private Vendas vendacad = new Vendas();  // venda e globals nunca são atribuídos e sempre serão null??
        List<object> objectsList = new();

        public VendasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendas.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id_vendas == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        

        // GET: Vendas/Create
        public IActionResult Create(string Nome_chapeu)
        {
            // carregar a lista de chapéus (repositório) e exibir no ASP-ITEMS do DDLChapéu

            var listaChapéus = RepositorioChapeu.getListaChapéus().Select(chapeu => new SelectListItem()
            { Text = chapeu.Nome_Chapéu, Value = chapeu.Nome_Chapéu }).ToList();

            ViewData["Chapéus"] = listaChapéus;

            var chapeu = RepositorioChapeu.getListaChapéus().Where(chapeu => chapeu.Nome_Chapéu.Equals(Nome_chapeu));

            return View();
        }

       

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venda_ViewModel venda)
        {
            // cs.Chapéus
            var listaChapéus = RepositorioChapeu.getListaChapéus().Select(chapeu => new SelectListItem()
            { Text = chapeu.Nome_Chapéu, Value = chapeu.Nome_Chapéu }).ToList();

            ViewData["Chapéus"] = listaChapéus;

            // cs.Vendas
            var chapeu = RepositorioChapeu.getListaChapéus().Where(chapeu => chapeu.Nome_Chapéu.Equals(venda.Nome_chapeu));

            foreach (var item in chapeu)
            {
                ViewData["Cor"] = item.Cor_Chapéu;
                ViewData["Price"] = item.Price;
                ViewData["QtdD"] = item.QtdAvailable;

                venda.Cor_Chapéu = item.Cor_Chapéu;
                venda.Price = item.Price;
                venda.QtdAvailable = item.QtdAvailable;
                venda.Nome_chapeu = item.Nome_Chapéu;

            }

            if (venda.Qtd <= venda.QtdAvailable && venda.Qtd != 0)
            {
                double total;
                total = venda.Price * venda.Qtd;
                ViewData["Total"] = total;
                venda.Total = total;

                vendacad.Nome_chapeu = venda.Nome_chapeu;
                vendacad.Nomecliente = venda.Nomecliente;
                vendacad.Data_compra = venda.Data_compra;
                vendacad.Nome_formapag = venda.Nome_formapag;
                vendacad.Qtd = venda.Qtd;
                vendacad.Total = venda.Total;
            }

            if (vendacad.Total != 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(vendacad); // colocando o vendas original para o database 
                    await _context.SaveChangesAsync();
                    // redirecionando para o Index
                    return RedirectToAction(nameof(Index));
                }            
            }

            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas == null)
            {
                return NotFound();
            }

            // carregar a lista de chapéus (repositório) e exibir no ASP-ITEMS do DDLChapéu

            var listaChapéus = RepositorioChapeu.getListaChapéus().Select(chapeu => new SelectListItem()
            { Text = chapeu.Nome_Chapéu, Value = chapeu.Nome_Chapéu }).ToList();

            ViewData["Chapéus"] = listaChapéus;

            var chapeu = RepositorioChapeu.getListaChapéus().Where(chapeu => chapeu.Nome_Chapéu.Equals(vendas.Nome_chapeu));


            var viewVenda = new Venda_ViewModel();

            foreach (var item in chapeu)
            {
                ViewData["Cor"] = item.Cor_Chapéu;
                ViewData["Price"] = item.Price;
                ViewData["QtdD"] = item.QtdAvailable;

                viewVenda.Cor_Chapéu = item.Cor_Chapéu;
                viewVenda.Price = item.Price;
                viewVenda.QtdAvailable = item.QtdAvailable;
                viewVenda.Nome_chapeu = item.Nome_Chapéu;

            }

            viewVenda.Id_vendas = vendas.Id_vendas;
            viewVenda.Nome_chapeu = vendas.Nome_chapeu;
            viewVenda.Nomecliente = vendas.Nomecliente;
            viewVenda.Data_compra = vendas.Data_compra;
            viewVenda.Nome_formapag = vendas.Nome_formapag;
            viewVenda.Qtd = vendas.Qtd;
            viewVenda.Total = vendas.Total;
            ViewData["Total"] = vendas.Total;

            return View(viewVenda);
        }


        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Nome_chapeu, Venda_ViewModel venda)
        {
            if (id != venda.Id_vendas)
            {
                return NotFound();
            }
            // cs.Chapéus
            var listaChapéus = RepositorioChapeu.getListaChapéus().Select(chapeu => new SelectListItem()
            { Text = chapeu.Nome_Chapéu, Value = chapeu.Nome_Chapéu }).ToList();

            ViewData["Chapéus"] = listaChapéus;

            // cs.Vendas
            var chapeu = RepositorioChapeu.getListaChapéus().Where(chapeu => chapeu.Nome_Chapéu.Equals(venda.Nome_chapeu));


            foreach (var item in chapeu)
            {
                ViewData["Cor"] = item.Cor_Chapéu;
                ViewData["Price"] = item.Price;
                ViewData["QtdD"] = item.QtdAvailable;

                venda.Cor_Chapéu = item.Cor_Chapéu;
                venda.Price = item.Price;
                venda.QtdAvailable = item.QtdAvailable;
                venda.Nome_chapeu = item.Nome_Chapéu;

            }

            if (venda.Qtd <= venda.QtdAvailable && venda.Qtd != 0)
            {
                double total;
                total = venda.Price * venda.Qtd;
                ViewData["Total"] = total;
                venda.Total = total;

                vendacad.Nome_chapeu = venda.Nome_chapeu;
                vendacad.Nomecliente = venda.Nomecliente;
                vendacad.Data_compra = venda.Data_compra;
                vendacad.Nome_formapag = venda.Nome_formapag;
                vendacad.Qtd = venda.Qtd;
                vendacad.Total = venda.Total;
                vendacad.Total = venda.Id_vendas;
            }

            if (vendacad.Total != 0) 
            // total já vem do create e nunca vai ser zero 
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(vendacad);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VendasExists(venda.Id_vendas))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id_vendas == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(vendas); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(int id)
        {
            return _context.Vendas.Any(e => e.Id_vendas == id);
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string? Nomecliente)
        {
            if (Nomecliente == null)
            {
               return BuscarErro();
                // return NotFound();
            }

            var venda = _context.Vendas.Where(v => v.Nomecliente.Contains(Nomecliente));
            if (venda == null)
            {
                return BuscarErro();
            }

            return View(venda);
        }

        public IActionResult BuscarErro()
        {
            return View();
        }

        public async Task<IActionResult> DeleteAuto(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(vendas); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

    internal class T
    {
    }
}
