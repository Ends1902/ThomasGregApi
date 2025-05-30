using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.Application;
using ThomasGreg.Domain;

namespace ThomasGreg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok(new ClienteDto
            {
                Nome = "João da Silva",
                Email = email,
                Logotipo = "https://example.com/logotipo.png"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto cliente)
        {
       
            return CreatedAtAction(nameof(Get), new { email = cliente.Email }, new { Message = $"O cliente com o email {cliente.Email} foi criado com sucesso." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteDto cliente)
        {
                return Ok(new { Message = $"O cliente com o email {cliente.Email} foi atualizado com sucesso." });
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
                return Ok(new { Message = $"O cliente com o email {email} foi deletado com sucesso." });
           
        }
    }
}
