using System;
using System.Collections.Generic;
using System.Text;
using ThomasGreg.Domain;

namespace ThomasGreg.Application
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public List<LogradouroDto> Logradouros { get; set; }

        public Cliente MapearClienteDtoParaEntidade(ClienteDto clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome, clienteDto.Email, clienteDto.Logotipo);

            foreach (var logradouroDto in clienteDto.Logradouros ?? new List<LogradouroDto>())
            {
                var logradouro = new Logradouro(
                    logradouroDto.Nome,
                    logradouroDto.Numero,
                    logradouroDto.Cep
                );

                logradouro.Email = clienteDto.Email; // Relacionamento

                cliente.Logradouros.Add(logradouro);
            }

            return cliente;
        }
    }
}
