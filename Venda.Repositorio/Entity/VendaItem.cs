namespace Venda.Repositorio.Entity
{
    public class VendaItem
    {
        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public double Preco { get; set; }
        public double Quantidadel { get; set; }
        public double SubTotal { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
    }
}
