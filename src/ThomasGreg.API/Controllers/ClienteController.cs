using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.Application;
using ThomasGreg.Application.Services;
using ThomasGreg.Domain;

namespace ThomasGreg.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("criarClientes")]
        public async Task<IActionResult> CriarClientes([FromBody] ClienteDto clienteDto)
        {
            await _clienteService.CriarClienteAsync(clienteDto.MapearClienteDtoParaEntidade(clienteDto));
            return CreatedAtAction(nameof(ObterClientes), new { email = clienteDto.Email }, clienteDto);
        }

        [HttpPut("atualizarClientes/{email}")]
        public async Task<IActionResult> AtualizarClientes(string email, [FromBody] ClienteDto clienteDto)
        {
            if (email != clienteDto.Email)
                return BadRequest("Email do cliente não é igual ao informado !!");

            await _clienteService.AtualizarClienteAsync(clienteDto.Nome, clienteDto.Email, clienteDto.Logotipo);
            return NoContent();
        }

        [HttpDelete("removerClientes/{email}")]
        public async Task<IActionResult> RemoverClientes(string email)
        {
            await _clienteService.RemoverClienteAsync(email);
            return NoContent();
        }

        [HttpGet("obterClientes/{email}")]
        public async Task<ActionResult<Cliente>> ObterClientes(string email)
        {
            var cliente = await _clienteService.ObterClienteComLogradourosAsync(email);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }

}
