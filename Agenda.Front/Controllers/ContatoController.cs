using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Front.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;
        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _contatoService.GetAllAsync());
        }
    }
}
