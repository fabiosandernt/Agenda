using Microsoft.AspNetCore.Mvc;
using Agenda.Application.Agenda.Services;
using Agenda.Application.Account.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda.Application.Agenda.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Agenda.Front.Controllers
{
    [Authorize]
    public class AgendasController : Controller
    {
        private readonly IAgendaService _agendaService;
        private readonly IUsuarioService _usuarioService;

        public AgendasController(IAgendaService agendaService, IUsuarioService usuarioService)
        {
            _agendaService = agendaService;
            _usuarioService = usuarioService;
        }

        // GET: Agendas
        public async Task<IActionResult> Index()
        {
            return View(await _agendaService.GetAllAsync());
        }

        // GET: Agendas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var agendaBook = await _agendaService.GetAgendaBookByIdAsync(id);
            return View(agendaBook);
        }

        //GET: Agendas/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "Nome");
            return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,UsuarioId,Id")] AgendaBookDto agendabookDto)
        {
            if (ModelState.IsValid)
            {
                await _agendaService.CreateAgendaAsync(agendabookDto);
                return RedirectToAction(nameof(Index));
            }
            var usuarios = await _usuarioService.GetAllAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "Nome", agendabookDto.UsuarioId);
            return View(agendabookDto);
        }

        //// GET: Agendas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var agenda = await _agendaService.GetAgendaBookByIdAsync(id);
            var usuarios = await _usuarioService.GetAllAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "Nome");
            return View(agenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,UsuarioId,Id")] AgendaBookDto agendabookDto)
        {
            if (ModelState.IsValid)
            {
                //id = agendabookDto.Id;
                await _agendaService.UpdateAgendaAsync(id, agendabookDto);
                return RedirectToAction(nameof(Index));
            }
            var usuarios = await _usuarioService.GetAllAsync();
            ViewData["UsuarioId"] = new SelectList(usuarios, "Id", "Nome", agendabookDto.UsuarioId);
            return View(agendabookDto);
        }

        //// GET: Agendas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _agendaService.GetAgendaBookByIdAsync(id));
        }

        //// POST: Agendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _agendaService.DeleteAgendaAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //private bool AgendaBookExists(Guid id)
        //{
        //    return (_context.Agendas?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
