using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.Application;
using ThomasGreg.Application.Services;
using ThomasGreg.Domain.Interfaces.Repositories;

namespace ThomasGreg.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService;

        public AuthController(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto loginDto)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorEmailAsync(loginDto.Email);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado.");


            var token = _tokenService.GerarToken(usuario);

            return Ok(new TokenDto { Token = token });
        }
    }
}
