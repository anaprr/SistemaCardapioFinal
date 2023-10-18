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
            var contexto = _context.Cardapio.Include(c => c.Acompanhamento).Include(c => c.Base).Include(c => c.Bebida).Include(c => c.Salada).Include(c => c.Sobremesa);
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
                .Include(c => c.Acompanhamento)
                .Include(c => c.Base)
                .Include(c => c.Bebida)
                .Include(c => c.Salada)
                .Include(c => c.Sobremesa)
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
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamento, "Id", "DescricaoAcompanhamento");
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "DescricaoBase");
            ViewData["BebidaId"] = new SelectList(_context.Bebida, "Id", "DescricaoBebida");
            ViewData["SaladaId"] = new SelectList(_context.Salada, "Id", "DescricaoSalada");
            ViewData["SobremesaId"] = new SelectList(_context.Sobremesa, "Id", "DescricaoSobremesa");
            return View();
        }

        // POST: Cardapio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardapioId,CardapioNome,BaseId,AcompanhamentoId,SaladaId,BebidaId,SobremesaId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardapio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamento, "Id", "DescricaoAcompanhamento", cardapio.AcompanhamentoId);
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "DescricaoBase", cardapio.BaseId);
            ViewData["BebidaId"] = new SelectList(_context.Bebida, "Id", "DescricaoBebida", cardapio.BebidaId);
            ViewData["SaladaId"] = new SelectList(_context.Salada, "Id", "DescricaoSalada", cardapio.SaladaId);
            ViewData["SobremesaId"] = new SelectList(_context.Sobremesa, "Id", "DescricaoSobremesa", cardapio.SobremesaId);
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
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamento, "Id", "DescricaoAcompanhamento", cardapio.AcompanhamentoId);
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "DescricaoBase", cardapio.BaseId);
            ViewData["BebidaId"] = new SelectList(_context.Bebida, "Id", "DescricaoBebida", cardapio.BebidaId);
            ViewData["SaladaId"] = new SelectList(_context.Salada, "Id", "DescricaoSalada", cardapio.SaladaId);
            ViewData["SobremesaId"] = new SelectList(_context.Sobremesa, "Id", "DescricaoSobremesa", cardapio.SobremesaId);
            return View(cardapio);
        }

        // POST: Cardapio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardapioId,CardapioNome,BaseId,AcompanhamentoId,SaladaId,BebidaId,SobremesaId")] Cardapio cardapio)
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
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamento, "Id", "DescricaoAcompanhamento", cardapio.AcompanhamentoId);
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "DescricaoBase", cardapio.BaseId);
            ViewData["BebidaId"] = new SelectList(_context.Bebida, "Id", "DescricaoBebida", cardapio.BebidaId);
            ViewData["SaladaId"] = new SelectList(_context.Salada, "Id", "DescricaoSalada", cardapio.SaladaId);
            ViewData["SobremesaId"] = new SelectList(_context.Sobremesa, "Id", "DescricaoSobremesa", cardapio.SobremesaId);
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
                .Include(c => c.Acompanhamento)
                .Include(c => c.Base)
                .Include(c => c.Bebida)
                .Include(c => c.Salada)
                .Include(c => c.Sobremesa)
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
