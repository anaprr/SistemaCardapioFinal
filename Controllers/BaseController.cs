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
    public class BaseController : Controller
    {
        private readonly Contexto _context;

        public BaseController(Contexto context)
        {
            _context = context;
        }

        // GET: Base
        public async Task<IActionResult> Index()
        {
              return _context.Base != null ? 
                          View(await _context.Base.ToListAsync()) :
                          Problem("Entity set 'Contexto.Base'  is null.");
        }

        // GET: Base/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Base == null)
            {
                return NotFound();
            }

            var @base = await _context.Base
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // GET: Base/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Base/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoBase")] Base @base)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@base);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@base);
        }

        // GET: Base/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Base == null)
            {
                return NotFound();
            }

            var @base = await _context.Base.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }
            return View(@base);
        }

        // POST: Base/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoBase")] Base @base)
        {
            if (id != @base.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@base);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseExists(@base.Id))
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
            return View(@base);
        }

        // GET: Base/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Base == null)
            {
                return NotFound();
            }

            var @base = await _context.Base
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // POST: Base/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Base == null)
            {
                return Problem("Entity set 'Contexto.Base'  is null.");
            }
            var @base = await _context.Base.FindAsync(id);
            if (@base != null)
            {
                _context.Base.Remove(@base);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseExists(int id)
        {
          return (_context.Base?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
