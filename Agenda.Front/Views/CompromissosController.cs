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
    public class CompromissosController : Controller
    {
        private readonly AgendaContext _context;

        public CompromissosController(AgendaContext context)
        {
            _context = context;
        }

        // GET: Compromissos
        public async Task<IActionResult> Index()
        {
            var agendaContext = _context.Compromissos.Include(c => c.Agenda);
            return View(await agendaContext.ToListAsync());
        }

        // GET: Compromissos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Compromissos == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos
                .Include(c => c.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // GET: Compromissos/Create
        public IActionResult Create()
        {
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome");
            return View();
        }

        // POST: Compromissos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Titulo,Descricao,HoraDeInicio,HoraDeTermino,AgendaId,Id")] Compromisso compromisso)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        compromisso.Id = Guid.NewGuid();
        //        _context.Add(compromisso);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", compromisso.AgendaId);
        //    return View(compromisso);
        //}

        // GET: Compromissos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Compromissos == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", compromisso.AgendaId);
            return View(compromisso);
        }

        // POST: Compromissos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Titulo,Descricao,HoraDeInicio,HoraDeTermino,AgendaId,Id")] Compromisso compromisso)
        {
            if (id != compromisso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compromisso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompromissoExists(compromisso.Id))
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
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", compromisso.AgendaId);
            return View(compromisso);
        }

        // GET: Compromissos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Compromissos == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos
                .Include(c => c.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Compromissos == null)
            {
                return Problem("Entity set 'AgendaContext.Compromissos'  is null.");
            }
            var compromisso = await _context.Compromissos.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromissos.Remove(compromisso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(Guid id)
        {
          return (_context.Compromissos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
