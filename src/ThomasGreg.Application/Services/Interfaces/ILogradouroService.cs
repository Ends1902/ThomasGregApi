using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application.Services.Interfaces
{
    public interface ILogradouroService
    {
        string GetLogradouro(string cep, string numero);
        void AdicionarLogradouro(int clienteId, string nome, string numero, string cep);
        void AtualizarLogradouro(int id, string nome, string numero, string cep);
        void RemoverLogradouro(int id);
    }
}
