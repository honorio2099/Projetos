using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadinhoNuvensFofas.Data;
using MercadinhoNuvensFofas.Models;

namespace MercadinhoNuvensFofas.Controllers
{
    public class VendasController : Controller
    {
        private readonly ApplicationContext _context;

        public VendasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Vendas.Include(v => v.Bebida).Include(v => v.FormaEntrega).Include(v => v.Produto);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Bebida)
                .Include(v => v.FormaEntrega)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["IdBeb"] = new SelectList(_context.Bebidas, "IdBeb", "NomeBeb");
            ViewData["IdForma"] = new SelectList(_context.FormaEntrega, "IdForma", "DescForma");
            ViewData["IdProd"] = new SelectList(_context.Produtos, "IdProd", "NomeProd");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdVenda,NomeCliente,IdProd,IdBeb,IdForma,DataCompra,QtdProd,QtdBeb,TotalPagar")] Venda venda)
        {

            //buscar o produto selecionado no DDL
            var produto = _context.Produtos.FirstOrDefault(p => p.IdProd == venda.IdProd);

            var bebida = _context.Bebidas.FirstOrDefault(b => b.IdBeb == venda.IdBeb);

            var formaEntrega = _context.FormaEntrega.FirstOrDefault(fe => fe.IdForma == venda.IdForma);

            //verificar se as qtd´s são suficientes
            if (produto.QtdDispProd >= venda.QtdProd && bebida.QtdDispBeb >= venda.QtdBeb)
            {
                /////////////////////////////////////////////////////////////////////////////
                double precoProd, precoBeb, total, totalFinal, acrescFormaEntrega;
                int qtdProd, qtdBeb;

                precoProd = produto.PrecoProd;
                precoBeb = bebida.PrecoBeb;

                qtdBeb = venda.QtdBeb;
                qtdProd = venda.QtdProd;

                acrescFormaEntrega = (double)formaEntrega.AcrescForma / 100;

                total = (qtdProd * precoProd) + (qtdBeb * precoBeb);
                totalFinal = total + (total * acrescFormaEntrega);
                ViewData["TotalPagar"] = totalFinal;
                /////////////////////////////////////////////////////////////////////////////
                if (venda.TotalPagar != 0)
                {
                    if (ModelState.IsValid)
                    {
                        // cadastrando uma venda
                        _context.Add(venda);
                        await _context.SaveChangesAsync();

                        // alteração da qtd do produto
                        ////////////////////////////////////////////
                        int qtdDesProd, qtdDisProd, qtdFinalProd;

                        qtdDesProd = venda.QtdProd;
                        qtdDisProd = produto.QtdDispProd;
                        qtdFinalProd = qtdDisProd - qtdDesProd;

                        ////////////////////////////////////
                        produto.QtdDispProd = qtdFinalProd;
                        _context.Add(produto);
                        await _context.SaveChangesAsync();

                        // alteração da qtd de bebida
                        ////////////////////////////////////
                        bebida.QtdDispBeb = bebida.QtdDispBeb - venda.QtdBeb;
                        _context.Add(produto);
                        await _context.SaveChangesAsync();


                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdBeb"] = new SelectList(_context.Bebidas, "IdBeb", "NomeBeb", venda.IdBeb);
            ViewData["IdForma"] = new SelectList(_context.FormaEntrega, "IdForma", "DescForma", venda.IdForma);
            ViewData["IdProd"] = new SelectList(_context.Produtos, "IdProd", "NomeProd", venda.IdProd);
            return View(venda);

        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.Include(v => v.Bebida)
                .Include(v => v.FormaEntrega)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);


            if (venda == null)
            {
                return NotFound();
            }
            ViewData["IdBeb"] = new SelectList(_context.Bebidas, "IdBeb", "NomeBeb", venda.IdBeb);
            ViewData["IdForma"] = new SelectList(_context.FormaEntrega, "IdForma", "DescForma", venda.IdForma);
            ViewData["IdProd"] = new SelectList(_context.Produtos, "IdProd", "NomeProd", venda.IdProd);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,NomeCliente,IdProd,IdBeb,IdForma,DataCompra,QtdProd,QtdBeb,TotalPagar")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var

                    bebida.QtdDispBeb = bebida.QtdDispBeb - venda.QtdBeb;
                    _context.Add(produto);
                    await _context.SaveChangesAsync();

                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
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
            ViewData["IdBeb"] = new SelectList(_context.Bebidas, "IdBeb", "NomeBeb", venda.IdBeb);
            ViewData["IdForma"] = new SelectList(_context.FormaEntrega, "IdForma", "DescForma", venda.IdForma);
            ViewData["IdProd"] = new SelectList(_context.Produtos, "IdProd", "NomeProd", venda.IdProd);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Bebida)
                .Include(v => v.FormaEntrega)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVenda == id);
        }
    }
}
