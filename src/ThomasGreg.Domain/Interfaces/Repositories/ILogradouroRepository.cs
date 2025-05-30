using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain.Interfaces.Repositories
{
    public interface ILogradouroRepository
    {
        string GetLogradouro(string cep, string numero);
        void AdicionarLogradouro(int clienteId, string nome, string numero, string cep);

    }
}
