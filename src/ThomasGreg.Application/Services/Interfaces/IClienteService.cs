using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Services
{
    public interface IClienteService
    {
        Task CriarClienteAsync(Cliente cliente);    
        Task AtualizarClienteAsync(string nome, string email, string logotipo);
        Task RemoverClienteAsync(string email);
        Task<Cliente> ObterClienteComLogradourosAsync(string email);
    }
}