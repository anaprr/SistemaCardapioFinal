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
    public class PratoController : Controller
    {
        private readonly Contexto _context;

        public PratoController(Contexto context)
        {
            _context = context;
        }

        // GET: Prato
        public async Task<IActionResult> Index()
        {
              return _context.Prato != null ? 
                          View(await _context.Prato.ToListAsync()) :
                          Problem("Entity set 'Contexto.Prato'  is null.");
        }

        // GET: Prato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.PratoId == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // GET: Prato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PratoId,DescricaoPrato,DescricaoBebida,DescricaoVegetariana")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prato);
        }

        // GET: Prato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }
            return View(prato);
        }

        // POST: Prato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PratoId,DescricaoPrato,DescricaoBebida,DescricaoVegetariana")] Prato prato)
        {
            if (id != prato.PratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratoExists(prato.PratoId))
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
            return View(prato);
        }

        // GET: Prato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.PratoId == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // POST: Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prato == null)
            {
                return Problem("Entity set 'Contexto.Prato'  is null.");
            }
            var prato = await _context.Prato.FindAsync(id);
            if (prato != null)
            {
                _context.Prato.Remove(prato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
          return (_context.Prato?.Any(e => e.PratoId == id)).GetValueOrDefault();
        }
    }
}
