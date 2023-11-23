using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Front.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUsuarioService _userService;
        private readonly IAuthService _authService;

        public AuthenticationController(IUsuarioService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var userRequest = await _authService.LoginAsync(loginRequest);
                if (userRequest == null)
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos");
                    return View(loginRequest);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(loginRequest);
        }
    }
}