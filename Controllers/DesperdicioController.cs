using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCardapioFinal.Models;

namespace SistemaCardapioFinal.Controllers
{
    public class DesperdicioController : Controller
    {
        private readonly Contexto _context;

        public DesperdicioController(Contexto context)
        {
            _context = context;
        }

        // GET: Desperdicio
        public async Task<IActionResult> Index()
        {
              return _context.Desperdicio != null ? 
                          View(await _context.Desperdicio.ToListAsync()) :
                          Problem("Entity set 'Contexto.Desperdicio'  is null.");
        }

        // GET: Desperdicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desperdicio == null)
            {
                return NotFound();
            }

            var desperdicio = await _context.Desperdicio
                .FirstOrDefaultAsync(m => m.DesperdicioId == id);
            if (desperdicio == null)
            {
                return NotFound();
            }

            return View(desperdicio);
        }

        // GET: Desperdicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desperdicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesperdicioId,NomeVeiculo,QtdAlimento,QtdDesperdicio,PorcentagemDesperdicio")] Desperdicio desperdicio)
        {
            if (ModelState.IsValid)
            {
                //Convert.ToDouble(desperdicio.PorcentagemDesperdicio);
                _context.Add(desperdicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desperdicio);
        }

        // GET: Desperdicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desperdicio == null)
            {
                return NotFound();
            }

            var desperdicio = await _context.Desperdicio.FindAsync(id);
            if (desperdicio == null)
            {
                return NotFound();
            }
            return View(desperdicio);
        }

        // POST: Desperdicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesperdicioId,NomeVeiculo,QtdAlimento,QtdDesperdicio,PorcentagemDesperdicio")] Desperdicio desperdicio)
        {
            if (id != desperdicio.DesperdicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desperdicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesperdicioExists(desperdicio.DesperdicioId))
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
            return View(desperdicio);
        }

        // GET: Desperdicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desperdicio == null)
            {
                return NotFound();
            }

            var desperdicio = await _context.Desperdicio
                .FirstOrDefaultAsync(m => m.DesperdicioId == id);
            if (desperdicio == null)
            {
                return NotFound();
            }

            return View(desperdicio);
        }

        // POST: Desperdicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desperdicio == null)
            {
                return Problem("Entity set 'Contexto.Desperdicio'  is null.");
            }
            var desperdicio = await _context.Desperdicio.FindAsync(id);
            if (desperdicio != null)
            {
                _context.Desperdicio.Remove(desperdicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesperdicioExists(int id)
        {
          return (_context.Desperdicio?.Any(e => e.DesperdicioId == id)).GetValueOrDefault();
        }
    }
}
