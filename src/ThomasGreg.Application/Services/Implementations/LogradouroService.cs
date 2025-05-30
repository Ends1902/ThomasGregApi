using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Domain;
using ThomasGreg.Infrastructure.Repositories;

namespace ThomasGreg.Application.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroService(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task CriarLogradouroAsync(string emailCliente, Logradouro logradouro)
        {
            await _logradouroRepository.InserirLogradouroAsync(emailCliente, logradouro);
        }

        public async Task AtualizarLogradouroAsync(Logradouro logradouro)
        {
            await _logradouroRepository.AtualizarLogradouroAsync(logradouro);
        }

        public async Task RemoverLogradouroAsync(int id)
        {
            await _logradouroRepository.RemoverLogradouroAsync(id);
        }

        public async Task<IEnumerable<Logradouro>> ListarLogradourosAsync()
        {
            return await _logradouroRepository.ListarLogradourosAsync();
        }
    }
}
