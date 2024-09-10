using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Algoritimo_Suites.Models;

namespace Algoritimo_Suites.Controllers
{
    public class FilialsController : Controller
    {
        private readonly DbContexto _context;

        public FilialsController(DbContexto context)
        {
            _context = context;
        }

        // GET: Filials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filiais.ToListAsync());
        }

        public IActionResult NovaFilial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovaFilial([Bind("Id")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filial);
        }


        [HttpPost, ActionName("DeletarFilial")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarFilial(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial != null)
            {
                _context.Filiais.Remove(filial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialExists(int id)
        {
            return _context.Filiais.Any(e => e.Id == id);
        }
    }
}
