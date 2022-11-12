using EscolaAmarelinhas.Data;
using EscolaAmarelinhas.Models;
using EscolaAmarelinhas.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> About()
        {
            IQueryable<DataMatriculaGroup> data =
                from aluno in _context.Alunos 
                group aluno by aluno.DataMatriculaAluno into DateGroup
                select new DataMatriculaGroup
                {
                    DataMatricula = DateGroup.Key,
                    AlunosCount = DateGroup.Count()
                };

            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}
