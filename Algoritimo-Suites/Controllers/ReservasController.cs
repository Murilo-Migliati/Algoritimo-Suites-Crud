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
    public class ReservasController : Controller
    {
        private readonly DbContexto _context;

        public ReservasController(DbContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Reservas.Include(r => r.Cliente).Include(r => r.Filial).Include(r => r.Funcionario);
            return View(await dbContexto.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> DetalhesReservas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Filial)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        [HttpGet]
        public IActionResult FazerReservas()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["FilialId"] = new SelectList(_context.Filiais, "Id", "Id");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FazerReservas([Bind("Id,NumQuarto,DatasReservadas,Preco,ClienteId,FuncionarioId,FilialId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", reserva.ClienteId);
            ViewData["FilialId"] = new SelectList(_context.Filiais, "Id", "Id", reserva.FilialId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "Id", reserva.FuncionarioId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> EditarReservas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", reserva.ClienteId);
            ViewData["FilialId"] = new SelectList(_context.Filiais, "Id", "Id", reserva.FilialId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "Id", reserva.FuncionarioId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarReservas(int id, [Bind("Id,NumQuarto,DatasReservadas,Preco,ClienteId,FuncionarioId,FilialId")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", reserva.ClienteId);
            ViewData["FilialId"] = new SelectList(_context.Filiais, "Id", "Id", reserva.FilialId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "Id", reserva.FuncionarioId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var reserva = await _context.Reservas
        //        .Include(r => r.Cliente)
        //        .Include(r => r.Filial)
        //        .Include(r => r.Funcionario)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (reserva == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reserva);
        //}

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("DeletarReservas")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarReservas(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
