using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application.Services.Interfaces
{
    public interface IClienteService
    {
        public void AdicionarCliente(string nome, string email, string telefone, string cep, string numero, string logradouro);
        public void AtualizarCliente(int id, string email, string logoTipo);
        public void RemoverCliente(int id);
        public void VisualizarCliente(int id, out string nome, out string email, out string logotipo);
    }
}
