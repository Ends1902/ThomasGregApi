using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThomasGreg.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorEmailAsync(string email);
    }
}
