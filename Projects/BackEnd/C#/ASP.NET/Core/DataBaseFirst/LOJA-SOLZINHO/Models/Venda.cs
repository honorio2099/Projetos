using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class Venda
    {
        public Venda()
        {
            ItemVenda = new HashSet<ItemVenda>();
        }

        public int IdVenda { get; set; }
        public int IdUsu { get; set; }
        public int? IdPagto { get; set; }
        public decimal? ValorVnd { get; set; }

        public virtual FormaPagto IdPagtoNavigation { get; set; }
        public virtual Usuario IdUsuNavigation { get; set; }
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}
