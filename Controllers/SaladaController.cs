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
    public class SaladaController : Controller
    {
        private readonly Contexto _context;

        public SaladaController(Contexto context)
        {
            _context = context;
        }

        // GET: Salada
        public async Task<IActionResult> Index()
        {
              return _context.Salada != null ? 
                          View(await _context.Salada.ToListAsync()) :
                          Problem("Entity set 'Contexto.Salada'  is null.");
        }

        // GET: Salada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salada == null)
            {
                return NotFound();
            }

            var salada = await _context.Salada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salada == null)
            {
                return NotFound();
            }

            return View(salada);
        }

        // GET: Salada/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoSalada")] Salada salada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salada);
        }

        // GET: Salada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salada == null)
            {
                return NotFound();
            }

            var salada = await _context.Salada.FindAsync(id);
            if (salada == null)
            {
                return NotFound();
            }
            return View(salada);
        }

        // POST: Salada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoSalada")] Salada salada)
        {
            if (id != salada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaladaExists(salada.Id))
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
            return View(salada);
        }

        // GET: Salada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salada == null)
            {
                return NotFound();
            }

            var salada = await _context.Salada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salada == null)
            {
                return NotFound();
            }

            return View(salada);
        }

        // POST: Salada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salada == null)
            {
                return Problem("Entity set 'Contexto.Salada'  is null.");
            }
            var salada = await _context.Salada.FindAsync(id);
            if (salada != null)
            {
                _context.Salada.Remove(salada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaladaExists(int id)
        {
          return (_context.Salada?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
