using System.Threading.Tasks;
using ThomasGreg.Domain;
using ThomasGreg.Infrastructure.Repositories;

namespace ThomasGreg.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CriarClienteAsync(Cliente cliente)
        {
            await _clienteRepository.InserirClienteComLogradourosAsync(cliente);
        }

        public async Task AtualizarClienteAsync(string nome, string email, string logotipo)
        {
            var cliente = new Cliente(nome, email, logotipo);
            await _clienteRepository.AtualizarClienteAsync(cliente);
        }

        public async Task RemoverClienteAsync(string email)
        {
            await _clienteRepository.RemoverClienteAsync(email);
        }

        public async Task<Cliente> ObterClienteComLogradourosAsync(string email)
        {
            return await _clienteRepository.ObterClienteComLogradourosAsync(email);
        }
    }
}
