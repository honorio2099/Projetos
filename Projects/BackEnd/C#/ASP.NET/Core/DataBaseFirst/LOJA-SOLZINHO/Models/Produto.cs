using System;
using System.Collections.Generic;

#nullable disable

namespace LOJA_SOLZINHO.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ItemVenda = new HashSet<ItemVenda>();
        }

        public int IdProd { get; set; }
        public string NomeProd { get; set; }
        public string DescProd { get; set; }
        public string Image1 { get; set; }
        public int Qtd { get; set; }
        public int IdTipo { get; set; }
        public decimal ValorProd { get; set; }

        public virtual TipoProd IdTipoNavigation { get; set; }
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}
