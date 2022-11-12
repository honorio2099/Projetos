using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class TipoProd
    {
        public TipoProd()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdTipo { get; set; }
        public string TipoProd1 { get; set; }
        public int PorcAumento { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
