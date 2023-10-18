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
    public class BebidaController : Controller
    {
        private readonly Contexto _context;

        public BebidaController(Contexto context)
        {
            _context = context;
        }

        // GET: Bebida
        public async Task<IActionResult> Index()
        {
              return _context.Bebida != null ? 
                          View(await _context.Bebida.ToListAsync()) :
                          Problem("Entity set 'Contexto.Bebida'  is null.");
        }

        // GET: Bebida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // GET: Bebida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bebida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoBebida")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bebida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bebida);
        }

        // GET: Bebida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return View(bebida);
        }

        // POST: Bebida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoBebida")] Bebida bebida)
        {
            if (id != bebida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bebida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidaExists(bebida.Id))
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
            return View(bebida);
        }

        // GET: Bebida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // POST: Bebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bebida == null)
            {
                return Problem("Entity set 'Contexto.Bebida'  is null.");
            }
            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida != null)
            {
                _context.Bebida.Remove(bebida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidaExists(int id)
        {
          return (_context.Bebida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
