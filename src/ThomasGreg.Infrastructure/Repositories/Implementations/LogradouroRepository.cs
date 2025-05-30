using System;
using System.Collections.Generic;
using System.Text;
using ThomasGreg.Domain.Interfaces.Repositories;

namespace ThomasGreg.Infrastructure.Repositories.Implementations
{
    public class LogradouroRepository : ILogradouroRepository
    {
        public void AdicionarLogradouro(int clienteId, string nome, string numero, string cep)
        {
            throw new NotImplementedException();
        }

        public string GetLogradouro(string cep, string numero)
        {
            throw new NotImplementedException();
        }
    }
}
