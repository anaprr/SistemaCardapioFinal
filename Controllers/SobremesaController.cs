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
    public class SobremesaController : Controller
    {
        private readonly Contexto _context;

        public SobremesaController(Contexto context)
        {
            _context = context;
        }

        // GET: Sobremesa
        public async Task<IActionResult> Index()
        {
              return _context.Sobremesa != null ? 
                          View(await _context.Sobremesa.ToListAsync()) :
                          Problem("Entity set 'Contexto.Sobremesa'  is null.");
        }

        // GET: Sobremesa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sobremesa == null)
            {
                return NotFound();
            }

            var sobremesa = await _context.Sobremesa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sobremesa == null)
            {
                return NotFound();
            }

            return View(sobremesa);
        }

        // GET: Sobremesa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sobremesa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoSobremesa")] Sobremesa sobremesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sobremesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sobremesa);
        }

        // GET: Sobremesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sobremesa == null)
            {
                return NotFound();
            }

            var sobremesa = await _context.Sobremesa.FindAsync(id);
            if (sobremesa == null)
            {
                return NotFound();
            }
            return View(sobremesa);
        }

        // POST: Sobremesa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoSobremesa")] Sobremesa sobremesa)
        {
            if (id != sobremesa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sobremesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobremesaExists(sobremesa.Id))
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
            return View(sobremesa);
        }

        // GET: Sobremesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sobremesa == null)
            {
                return NotFound();
            }

            var sobremesa = await _context.Sobremesa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sobremesa == null)
            {
                return NotFound();
            }

            return View(sobremesa);
        }

        // POST: Sobremesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sobremesa == null)
            {
                return Problem("Entity set 'Contexto.Sobremesa'  is null.");
            }
            var sobremesa = await _context.Sobremesa.FindAsync(id);
            if (sobremesa != null)
            {
                _context.Sobremesa.Remove(sobremesa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobremesaExists(int id)
        {
          return (_context.Sobremesa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
