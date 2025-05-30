using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        Task InserirClienteComLogradourosAsync(Cliente cliente);
        Task AtualizarClienteAsync(Cliente cliente);
        Task RemoverClienteAsync(string email);
        Task<Cliente> ObterClienteComLogradourosAsync(string email);
    }
}