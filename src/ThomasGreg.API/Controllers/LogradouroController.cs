using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.Application;
using ThomasGreg.Application.Services;

namespace ThomasGreg.Api.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/[controller]")]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;

        public LogradouroController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        [HttpPost("criarLogradouros")]
        public async Task<IActionResult> CriarLogradouros(string emailCliente, [FromBody] LogradouroDto logradouroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _logradouroService.CriarLogradouroAsync(emailCliente, logradouroDto.MapearLogradouroDtoParaEntidade(0, emailCliente, logradouroDto));
            return Created("", logradouroDto);
        }

        [HttpPut("atualizarLogradouros/{id}")]
        public async Task<IActionResult> AtualizarLogradouros(int id, string emailCliente, [FromBody] LogradouroDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _logradouroService.AtualizarLogradouroAsync(dto.MapearLogradouroDtoParaEntidade(id, emailCliente, dto));
            return NoContent();
        }

        [HttpDelete("removerLogradouros/{id}")]
        public async Task<IActionResult> RemoverLogradouros(int id)
        {
            await _logradouroService.RemoverLogradouroAsync(id);
            return NoContent();
        }

        [HttpGet("listarLogradouros")]
        public async Task<IActionResult> ListarLogradouros()
        {
            var logradouros = await _logradouroService.ListarLogradourosAsync();
            return Ok(logradouros);
        }
    }
}
