using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscolaAmarelinha.Data;
using EscolaAmarelinha.Models;

namespace EscolaAmarelinha.Controllers
{
    public class BoletimController : Controller
    {
        private readonly ApplicationContext _context;

        public BoletimController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Boletim
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Boletim.Include(b => b.Aluno).Include(b => b.Disciplina); // - Inner Join das duas classes
            return View(await applicationContext.ToListAsync());
        }

        // GET: Boletim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletim = await _context.Boletim
                .Include(b => b.Aluno)
                .Include(b => b.Disciplina)
                .FirstOrDefaultAsync(m => m.IdBoletim == id);
            if (boletim == null)
            {
                return NotFound();
            }

            return View(boletim);
        }

        // GET: Boletim/Create
        public IActionResult Create()
        {
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "Id", "NomeAluno"); // - sempre mudar o último para o nome do objeto/item, visto que é o que aparece na visualização
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "NomeDisciplina");
            return View();
        }

        // POST: Boletim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBoletim,IdAluno,IdDisciplina,NotaDisciplina")] Boletim boletim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boletim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "Id", "Id", boletim.IdAluno);
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "idDisciplina", boletim.IdDisciplina);
            return View(boletim);
        }

        // GET: Boletim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletim = await _context.Boletim.FindAsync(id);
            if (boletim == null)
            {
                return NotFound();
            }
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "Id", "NomeAluno", boletim.IdAluno);
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "NomeDisciplina", boletim.IdDisciplina);
            return View(boletim);
        }

        // POST: Boletim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBoletim,IdAluno,IdDisciplina,NotaDisciplina")] Boletim boletim)
        {
            if (id != boletim.IdBoletim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boletim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletimExists(boletim.IdBoletim))
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
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "Id", "NomeAluno", boletim.IdAluno);
            ViewData["IdDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "NomeDisciplina", boletim.IdDisciplina);
            return View(boletim);
        }

        // GET: Boletim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletim = await _context.Boletim
                .Include(b => b.Aluno)
                .Include(b => b.Disciplina)
                .FirstOrDefaultAsync(m => m.IdBoletim == id);
            if (boletim == null)
            {
                return NotFound();
            }

            return View(boletim);
        }

        // POST: Boletim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boletim = await _context.Boletim.FindAsync(id);
            _context.Boletim.Remove(boletim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletimExists(int id)
        {
            return _context.Boletim.Any(e => e.IdBoletim == id);
        }
    }
}
