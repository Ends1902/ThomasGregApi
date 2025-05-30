using System;
using System.Collections.Generic;
using System.Text;
using ThomasGreg.Domain;

namespace ThomasGreg.Application
{
    public class LogradouroDto
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

        public Logradouro MapearLogradouroDtoParaEntidade(int id, string emailCliente, LogradouroDto logradouroDto)
        {
            return id > 0 ? new Logradouro(id, logradouroDto.Nome, logradouroDto.Numero, logradouroDto.Cep, emailCliente) : new Logradouro(logradouroDto.Nome, logradouroDto.Numero, logradouroDto.Cep, emailCliente);
        }
    }
}
