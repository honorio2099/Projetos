using System;
using System.Collections.Generic;

#nullable disable

namespace LoginComSession.Models
{
    public partial class Usuario
    {
        public int IdUsu { get; set; }
        public string NomeUsu { get; set; }
        public string LoginUsu { get; set; }
        public string SenhaUsu { get; set; }
        public string TipoUsu { get; set; }
    }
}
