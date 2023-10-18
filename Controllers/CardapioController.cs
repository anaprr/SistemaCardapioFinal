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
    public class CardapioController : Controller
    {
        private readonly Contexto _context;

        public CardapioController(Contexto context)
        {
            _context = context;
        }

        // GET: Cardapio
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Cardapio.Include(c => c.Prato);
            return View(await contexto.ToListAsync());
        }

        // GET: Cardapio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cardapio == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio
                .Include(c => c.Prato)
                .FirstOrDefaultAsync(m => m.CardapioId == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // GET: Cardapio/Create
        public IActionResult Create()
        {
            ViewData["PratoId"] = new SelectList(_context.Prato, "PratoId", "DescricaoPrato");
            return View();
        }

        // POST: Cardapio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardapioId,CardapioNome,PratoId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardapio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PratoId"] = new SelectList(_context.Prato, "PratoId", "DescricaoPrato", cardapio.PratoId);
            return View(cardapio);
        }

        // GET: Cardapio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cardapio == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio.FindAsync(id);
            if (cardapio == null)
            {
                return NotFound();
            }
            ViewData["PratoId"] = new SelectList(_context.Prato, "PratoId", "DescricaoPrato", cardapio.PratoId);
            return View(cardapio);
        }

        // POST: Cardapio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardapioId,CardapioNome,PratoId")] Cardapio cardapio)
        {
            if (id != cardapio.CardapioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardapio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardapioExists(cardapio.CardapioId))
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
            ViewData["PratoId"] = new SelectList(_context.Prato, "PratoId", "DescricaoPrato", cardapio.PratoId);
            return View(cardapio);
        }

        // GET: Cardapio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cardapio == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapio
                .Include(c => c.Prato)
                .FirstOrDefaultAsync(m => m.CardapioId == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // POST: Cardapio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cardapio == null)
            {
                return Problem("Entity set 'Contexto.Cardapio'  is null.");
            }
            var cardapio = await _context.Cardapio.FindAsync(id);
            if (cardapio != null)
            {
                _context.Cardapio.Remove(cardapio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardapioExists(int id)
        {
          return (_context.Cardapio?.Any(e => e.CardapioId == id)).GetValueOrDefault();
        }
    }
}
