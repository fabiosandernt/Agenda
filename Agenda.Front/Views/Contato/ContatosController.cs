using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Context;
using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;

namespace Agenda.Front.Views.Contato
{
    public class ContatosController : Controller
    {
        private readonly AgendaContext _context;        

        public ContatosController(AgendaContext context)
        {            
            _context = context;
        }

        //GET: Contatos
        public async Task<IActionResult> Index()
        {
            var agendaContext = _context.Contatos.Include(c => c.Agenda);
            return View(await agendaContext.ToListAsync());
        }

        //public async Task<IActionResult> Index()
        //{
        //    var agenda = await _contatoService.GetAllAsync();
        //    
        //    return View(agenda.ToList());
        //}

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .Include(c => c.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome");
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Telefone,AgendaId,Id")] ContatoDto contato)
        {
            if (ModelState.IsValid)
            {
                contato.Id = Guid.NewGuid();
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", contato.AgendaId);
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", contato.AgendaId);
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Telefone,AgendaId,Id")] ContatoDto contato)
        //{
        //    if (id != contato.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(contato);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContatoExists(contato.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", contato.AgendaId);
        //    return View(contato);
        //}

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .Include(c => c.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'AgendaContext.Contatos'  is null.");
            }
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(Guid id)
        {
          return (_context.Contatos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
