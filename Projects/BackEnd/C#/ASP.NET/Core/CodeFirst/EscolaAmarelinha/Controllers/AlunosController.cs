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
    public class AlunosController : Controller
    {
        private readonly ApplicationContext _context;

        public AlunosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string ordem, string filtro, string filtroAtual, int? pageNumber)
        {
            ViewData["OrdemAtual"] = ordem;

            ViewData["NomeParam"] = String.IsNullOrEmpty(ordem) ? "NomeAluno" : "";
            ViewData["DataParam"] = ordem == "Data" ? "DataMatriculaAluno" : "Data";

            var alunos = from aluno in _context.Alunos select aluno;
            // acima o context refere-se ao nome da tabela no Application Context (contexto atual) e as variáveis aluno de from aluno e select aluno
            // poderiam ser qualquer outra coisa, mas é mais condizente chamar de aluno nesse caso né

            if (filtro != null)
            {
                pageNumber = 1;
            }
            else
            {
                filtro = filtroAtual;
            }

            ViewData["CurrentFilter"] = filtro;

            if (!String.IsNullOrEmpty(filtro))
            {
                alunos = alunos.Where(al => al.NomeAluno.Contains(filtro));
                // exemplo - && para filtros extras 
            }

            /* o código abaixo é o mesmo que o de cima
             * 
             * if (String.IsNullOrEmpty(ordem) == true)
                ViewData["NomeParam"] = "NomeAluno";
            else
                ViewData["NomeParam"] = "";

            if (ordem == "Data")
                ViewData["DataParam"] = "DataMatriculaAluno";
            else
                ViewData["DataParam"] = "Data";*/



            switch (ordem)
            {
                case "NomeAluno":
                    alunos = alunos.OrderBy(al => al.NomeAluno);
                    break;
                case "Data": // - Data é o mesmo que o DataMatriculaAluno mas em ordem de data mais nova para mais velha
                    alunos = alunos.OrderBy(al => al.DataMatriculaAluno);
                    break;
                case "Datamatricula": // o mesmo que o Data, mas em ordem de data mais velha para mais nova
                    alunos = alunos.OrderByDescending(al => al.DataMatriculaAluno);
                    break;
                default:
                    alunos = alunos.OrderByDescending(al => al.NomeAluno);
                    break;
            }

            int pageSize = 4;

            // .ToListAsync() executa o comando SELECT * FROM
            return View(await PaginatedList<Aluno>.CreateAsync(alunos.AsNoTracking(),pageNumber ?? 1, pageSize));
            // a dupla interrogação significa que se for nulo, recebe o número 1 como determinado,
            // caso já tenha uma informação carregada, ela é considerada
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
                .ThenInclude(disc => disc.Disciplina) // - grudando a lista de disciplinas nos detalhes da nota do aluno
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
        public async Task<IActionResult> Create([Bind("DataMatriculaAluno,Id,Idade,MensalidadeAluno,NomeAluno,CursoAluno,GeneroAluno")] Aluno aluno)
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
        public async Task<IActionResult> Edit(int id, [Bind("DataMatriculaAluno,Id,Idade,MensalidadeAluno,NomeAluno,CursoAluno,GeneroAluno")] Aluno aluno)
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
                    // if (AlunoExists(aluno.Id)== false) - a exclamação faz isso, basicamente
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
