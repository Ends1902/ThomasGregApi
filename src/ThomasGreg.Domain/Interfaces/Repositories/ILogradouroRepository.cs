using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Infrastructure.Repositories
{
    public interface ILogradouroRepository
    {
        Task<IEnumerable<Logradouro>> ListarLogradourosAsync();
        Task InserirLogradouroAsync(Logradouro logradouro);
        Task AtualizarLogradouroAsync(Logradouro logradouro);
        Task RemoverLogradouroAsync(int logradouroId);
    }
}