using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscolaAmarelinhas.Data;
using EscolaAmarelinhas.Models;

namespace EscolaAmarelinhas.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationContext _context;

        public AlunosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string ordem, string filtro,
            string filtroAtual, int? pageNumber)
        {
            ViewData["OrdemAtual"] = ordem;

            ViewData["NomeParam"] = String.IsNullOrEmpty(ordem) ? "NomeZA" : "";
            ViewData["DataParam"] = ordem == "DataAZ" ? "DataZA" : "DataAZ";

            if (filtro != null)
            {
                pageNumber = 1;
            }
            else
            {
                filtro = filtroAtual;
            }

            ViewData["CurrentFilter"] = filtro;

            var alunos = from aluno in _context.Alunos select aluno;

            if (!String.IsNullOrEmpty(filtro))
            {
                alunos = alunos.Where(al => al.NomeAluno.Contains(filtro));
            }

            switch (ordem)
            {
                case "NomeZA":
                    alunos = alunos.OrderByDescending(al => al.NomeAluno);
                    break;

                case "DataAZ":
                    alunos = alunos.OrderBy(al => al.DataMatriculaAluno);
                    break;

                case "DataZA":
                    alunos = alunos.OrderByDescending(al => al.DataMatriculaAluno);
                    break;

                default:
                    alunos = alunos.OrderBy(al => al.NomeAluno);
                    break;
            }

            int pageSize = 3;

            // .ToListAsync() irá executar o comando SELECT * FROM
            return View(await PaginatedList<Aluno>.CreateAsync(
                alunos.AsNoTracking(),pageNumber ?? 1,pageSize));
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(boletim => boletim.Boletim)
                .ThenInclude(disc => disc.Disciplina)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,NomeAluno,CursoAluno,SexoAluno,IdadeAluno,MensalidadeAluno,DataMatriculaAluno")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,NomeAluno,CursoAluno,SexoAluno,IdadeAluno,MensalidadeAluno,DataMatriculaAluno")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if(AlunoExists(aluno.Id)==false)
                    if (!AlunoExists(aluno.Id))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
