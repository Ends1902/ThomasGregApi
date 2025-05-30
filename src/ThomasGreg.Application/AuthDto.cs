using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application
{
    public class AuthDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class TokenDto
    {
        public string Token { get; set; }
    }
}
