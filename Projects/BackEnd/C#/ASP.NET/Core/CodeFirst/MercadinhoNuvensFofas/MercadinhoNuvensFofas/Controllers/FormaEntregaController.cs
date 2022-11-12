using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadinhoNuvensFofas.Models;
using MercadinhoNuvensFofas.Models.Data;

namespace MercadinhoNuvensFofas.Controllers
{
    public class FormaEntregaController : Controller
    {
        private readonly ApplicationContext _context;

        public FormaEntregaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: FormaEntrega
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaDeEntrega.ToListAsync());
        }

        // GET: FormaEntrega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaEntrega = await _context.FormaDeEntrega
                .FirstOrDefaultAsync(m => m.IdForma == id);
            if (formaEntrega == null)
            {
                return NotFound();
            }

            return View(formaEntrega);
        }

        // GET: FormaEntrega/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaEntrega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdForma,DescForma,AcrescForma")] FormaEntrega formaEntrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaEntrega);
        }

        // GET: FormaEntrega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaEntrega = await _context.FormaDeEntrega.FindAsync(id);
            if (formaEntrega == null)
            {
                return NotFound();
            }
            return View(formaEntrega);
        }

        // POST: FormaEntrega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdForma,DescForma,AcrescForma")] FormaEntrega formaEntrega)
        {
            if (id != formaEntrega.IdForma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaEntregaExists(formaEntrega.IdForma))
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
            return View(formaEntrega);
        }

        // GET: FormaEntrega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaEntrega = await _context.FormaDeEntrega
                .FirstOrDefaultAsync(m => m.IdForma == id);
            if (formaEntrega == null)
            {
                return NotFound();
            }

            return View(formaEntrega);
        }

        // POST: FormaEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaEntrega = await _context.FormaDeEntrega.FindAsync(id);
            _context.FormaDeEntrega.Remove(formaEntrega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaEntregaExists(int id)
        {
            return _context.FormaDeEntrega.Any(e => e.IdForma == id);
        }
    }
}
