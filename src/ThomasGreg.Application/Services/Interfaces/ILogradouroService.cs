using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Services
{
    public interface ILogradouroService
    {
        Task CriarLogradouroAsync(string emailCliente, Logradouro logradouro);
        Task AtualizarLogradouroAsync(Logradouro logradouro);
        Task RemoverLogradouroAsync(int id);
        Task<IEnumerable<Logradouro>> ListarLogradourosAsync();
    }
}