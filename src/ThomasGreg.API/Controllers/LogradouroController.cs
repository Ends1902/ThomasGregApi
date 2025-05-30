using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.Application;
using ThomasGreg.Application.Services;

namespace ThomasGreg.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;

        public LogradouroController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        [HttpPost("criarLogradouros")]
        public async Task<IActionResult> CriarLogradouros([FromBody] LogradouroDto logradouroDto)
        {
            await _logradouroService.CriarLogradouroAsync(logradouroDto.MapearLogradouroDtoParaEntidade(0, logradouroDto));
            return Created("", logradouroDto);
        }

        [HttpPut("atualizarLogradouros/{id}")]
        public async Task<IActionResult> AtualizarLogradouros(int id, [FromBody] LogradouroDto dto)
        {
            await _logradouroService.AtualizarLogradouroAsync(dto.MapearLogradouroDtoParaEntidade(id, dto));
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
