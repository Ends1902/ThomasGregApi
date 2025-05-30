using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        public void Adicionar(Cliente cliente);
        public void Atualizar(Cliente cliente);
        public void Remover(int id);
        public Cliente ObterPorEmail(int id);
    }
}
