using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venda = new HashSet<Venda>();
        }

        public int IdUsu { get; set; }
        public string NomeUsu { get; set; }
        public string LoginUsu { get; set; }
        public string SenhaUsu { get; set; }
        public string TipoUsu { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
