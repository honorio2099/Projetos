using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class FormaPagto
    {
        public FormaPagto()
        {
            Venda = new HashSet<Venda>();
        }

        public int IdPagto { get; set; }
        public string TipoPagto { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
