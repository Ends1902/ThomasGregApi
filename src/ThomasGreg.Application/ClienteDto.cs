using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public IEnumerable<LogradouroDto> Logradouros { get; set; }
    }
}
