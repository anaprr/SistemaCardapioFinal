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
    public class AcompanhamentoController : Controller
    {
        private readonly Contexto _context;

        public AcompanhamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Acompanhamento
        public async Task<IActionResult> Index()
        {
              return _context.Acompanhamento != null ? 
                          View(await _context.Acompanhamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Acompanhamento'  is null.");
        }

        // GET: Acompanhamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acompanhamento == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        // GET: Acompanhamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acompanhamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoAcompanhamento")] Acompanhamento acompanhamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acompanhamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acompanhamento);
        }

        // GET: Acompanhamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acompanhamento == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamento.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }
            return View(acompanhamento);
        }

        // POST: Acompanhamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoAcompanhamento")] Acompanhamento acompanhamento)
        {
            if (id != acompanhamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acompanhamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcompanhamentoExists(acompanhamento.Id))
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
            return View(acompanhamento);
        }

        // GET: Acompanhamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acompanhamento == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        // POST: Acompanhamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acompanhamento == null)
            {
                return Problem("Entity set 'Contexto.Acompanhamento'  is null.");
            }
            var acompanhamento = await _context.Acompanhamento.FindAsync(id);
            if (acompanhamento != null)
            {
                _context.Acompanhamento.Remove(acompanhamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcompanhamentoExists(int id)
        {
          return (_context.Acompanhamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
