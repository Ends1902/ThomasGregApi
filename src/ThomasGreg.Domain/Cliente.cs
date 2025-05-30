using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain
{
    public  class Cliente
    {
    
        public Cliente()
        {
        }

        public Cliente(string nome, string email, string logotipo)
        {
            Nome = nome;
            Email = email;
            Logotipo = logotipo;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Logotipo { get; private set; }
        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();

        public void AtualizarCliente(string email, string logoTipo)
            {
                Email = email ?? throw new ArgumentNullException(nameof(email));
                Logotipo = logoTipo ?? throw new ArgumentNullException(nameof(logoTipo));
            }
        }

       
}
