using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Context;

namespace Agenda.Front.Views
{
    public class AgendasController : Controller
    {
        private readonly AgendaContext _context;

        public AgendasController(AgendaContext context)
        {
            _context = context;
        }

        // GET: Agendas
        public async Task<IActionResult> Index()
        {
            var agendaContext = _context.Agendas.Include(a => a.Usuario);
            return View(await agendaContext.ToListAsync());
        }

        // GET: Agendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Agendas == null)
            {
                return NotFound();
            }

            var agendaBook = await _context.Agendas
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaBook == null)
            {
                return NotFound();
            }

            return View(agendaBook);
        }

        // GET: Agendas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Agendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Nome,UsuarioId,Id")] AgendaBook agendaBook)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        agendaBook.Id = Guid.NewGuid();
        //        _context.Add(agendaBook);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", agendaBook.UsuarioId);
        //    return View(agendaBook);
        //}

        // GET: Agendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Agendas == null)
            {
                return NotFound();
            }

            var agendaBook = await _context.Agendas.FindAsync(id);
            if (agendaBook == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", agendaBook.UsuarioId);
            return View(agendaBook);
        }

        // POST: Agendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,UsuarioId,Id")] AgendaBook agendaBook)
        {
            if (id != agendaBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendaBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaBookExists(agendaBook.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", agendaBook.UsuarioId);
            return View(agendaBook);
        }

        // GET: Agendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Agendas == null)
            {
                return NotFound();
            }

            var agendaBook = await _context.Agendas
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaBook == null)
            {
                return NotFound();
            }

            return View(agendaBook);
        }

        // POST: Agendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Agendas == null)
            {
                return Problem("Entity set 'AgendaContext.Agendas'  is null.");
            }
            var agendaBook = await _context.Agendas.FindAsync(id);
            if (agendaBook != null)
            {
                _context.Agendas.Remove(agendaBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaBookExists(Guid id)
        {
          return (_context.Agendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
