using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services.JwtServices;
using Agenda.Domain.Agendas.Repository;

namespace Agenda.Application.Account.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest request)
        {
            var user = await _usuarioRepository.GetByExpressionAsync(x => x.Email.Valor == request.Email);
            if (user == null) { return null; }
            var jwtToken = await _jwtService.GenerateToken(new JwtDto(user.Id, user.Email.Valor));

            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email.Valor,
                JwtToken = jwtToken,
            };
        }
    }
}
