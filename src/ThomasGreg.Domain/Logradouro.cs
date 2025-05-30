using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain
{
    public class Logradouro
    {
        public Logradouro()
        {

        }
        public Logradouro(int id, string nome, string numero, string cep)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            Cep = cep ?? throw new ArgumentNullException(nameof(cep));
            Email = string.Empty;
        }

        public Logradouro(string nome, string numero, string cep)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            Cep = cep ?? throw new ArgumentNullException(nameof(cep));
            Email = string.Empty;
        }
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }
        public string Email { get; set; } 

        public void AtualizarLogradouro(string nome, string numero, string cep)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            Cep = cep ?? throw new ArgumentNullException(nameof(cep));
        }
    }
}
