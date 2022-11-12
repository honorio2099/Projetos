using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LOJA_SOLZINHO.Data;
using LOJA_SOLZINHO.Models;

namespace LOJA_SOLZINHO.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly ApplicationContext _context;

        public TipoProdutoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TipoProduto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProds.ToListAsync());
        }

        // GET: TipoProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProd = await _context.TipoProds
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoProd == null)
            {
                return NotFound();
            }

            return View(tipoProd);
        }

        // GET: TipoProduto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,TipoProd1,PorcAumento")] TipoProd tipoProd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProd);
        }

        // GET: TipoProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProd = await _context.TipoProds.FindAsync(id);
            if (tipoProd == null)
            {
                return NotFound();
            }
            return View(tipoProd);
        }

        // POST: TipoProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,TipoProd1,PorcAumento")] TipoProd tipoProd)
        {
            if (id != tipoProd.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdExists(tipoProd.IdTipo))
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
            return View(tipoProd);
        }

        // GET: TipoProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProd = await _context.TipoProds
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoProd == null)
            {
                return NotFound();
            }

            return View(tipoProd);
        }

        // POST: TipoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProd = await _context.TipoProds.FindAsync(id);
            _context.TipoProds.Remove(tipoProd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdExists(int id)
        {
            return _context.TipoProds.Any(e => e.IdTipo == id);
        }
    }
}
