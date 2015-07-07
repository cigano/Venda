using System;
using System.Collections.Generic;

namespace Venda.Repositorio.Entity
{
    public class Venda
    {
        public Venda()
        {
            Itens = new List<VendaItem>();
        }

        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double SubTotal { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
        public virtual ICollection<VendaItem> Itens { get; set; }
    }
}
