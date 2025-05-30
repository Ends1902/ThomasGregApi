using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain
{
    public class Logradouro
    {
        public Logradouro(string nome, string numero)
        {
            Nome = nome;
            Numero = numero;
        }
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }

        public void AtualizarLogradouro(string nome, string numero, string cep)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            Cep = cep ?? throw new ArgumentNullException(nameof(cep));
        }
    }
}
