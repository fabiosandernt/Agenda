using Microsoft.AspNetCore.Mvc;
using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Agenda.Front.Controllers
{
    //[Authorize]
    public class ContatosController : Controller
    {
        private readonly IContatoService _contatoService;
        private readonly IAgendaService _agendaService;

        public ContatosController(IContatoService contatoService, IAgendaService agendaService)
        {
            _contatoService = contatoService;
            _agendaService = agendaService;
        }
        //GetAll
        public async Task<IActionResult> Index()
        {
            return View(await _contatoService.GetAllAsync());
        }
        //GetById
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _contatoService.GetById(id));
        }
        //GetCreate
        public async Task<IActionResult> Create()
        {
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Telefone,AgendaId")] ContatoDto contatoDto, Guid id)
        {

            if (ModelState.IsValid)
            {
                id = contatoDto.AgendaId;
                await _contatoService.CreateContatoAsync(contatoDto, id);
                return RedirectToAction(nameof(Index));
            }
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome", contatoDto.AgendaId);
            return View(contatoDto);
        }
        //GetUpdate
        public async Task<IActionResult> Edit(Guid id)
        {
            var contato = await _contatoService.GetById(id);
            if (contato == null)
                return NotFound("O contato não foi encontrado");
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, [Bind("Nome,Telefone,AgendaId,Id")] ContatoDto contatoDto)
        {
            if (ModelState.IsValid)
            {
                await _contatoService.UpdateContatoAsync(id, contatoDto);
                return RedirectToAction(nameof(Index));
            }
            var agendas = await _agendaService.GetAllAsync();
            ViewData["AgendaId"] = new SelectList(agendas, "Id", "Nome", contatoDto.AgendaId);
            return View();
        }
        //Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var contato = await _contatoService.GetById(id);
            return View(contato);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _contatoService.DeleteContatoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}