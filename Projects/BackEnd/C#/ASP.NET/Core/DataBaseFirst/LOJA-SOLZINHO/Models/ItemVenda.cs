using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class ItemVenda
    {
        public int IdItemVenda { get; set; }
        public int IdVenda { get; set; }
        public int IdProd { get; set; }
        public int QtdItem { get; set; }
        public decimal TotalItem { get; set; }

        public virtual Produto IdProdNavigation { get; set; }
        public virtual Venda IdVendaNavigation { get; set; }
    }
}
