using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Role { get; set; }
    }
}
