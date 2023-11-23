using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda.Application.Agenda.Services;
using Agenda.Application.Agenda.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Agenda.Front.Controllers
{
    //[Authorize]
    public class CompromissosController : Controller
    {
        private readonly ICompromissoService _compromissoService;
        private readonly IAgendaService _agendaService;

        public CompromissosController(ICompromissoService compromissoService, IAgendaService agendaService)
        {
            _compromissoService = compromissoService;
            _agendaService = agendaService;
        }

        // GET: Compromissos
        public async Task<IActionResult> Index()
        {
            return View(await _compromissoService.GetAllAsync());
        }

        // GET: Compromissos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View (await _compromissoService.GetById(id));
        }

        // GET: Compromissos/Create
        public async Task <IActionResult> Create()
        {
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descricao,HoraDeInicio,HoraDeTermino,AgendaId,Id")] CompromissoDto compromissoDto, Guid id)
        {
            if (ModelState.IsValid)
            {
                id = compromissoDto.AgendaId;
                await _compromissoService.CreateCompromissoAsync(compromissoDto, id);
                return RedirectToAction(nameof(Index));
            }
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome", compromissoDto.AgendaId);
            return View(compromissoDto);
        }

        // GET: Compromissos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var compromisso = await _compromissoService.GetById(id);
            if (compromisso == null)
                return NotFound("O compromisso não foi encontrado");
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Titulo,Descricao,HoraDeInicio,HoraDeTermino,AgendaId,Id")] CompromissoDto compromissoDto)
        {
            if (ModelState.IsValid)
            {
                await _compromissoService.UpdateCompromissoAsync(id, compromissoDto);
                return RedirectToAction(nameof(Index));
            }
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome", compromissoDto.AgendaId);
            return View();
        }

        // GET: Compromissos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var compromisso = await _compromissoService.GetById(id);
            return View(compromisso);
        }

        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _compromissoService.DeleteCompromissoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
