using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Venda.Repositorio.Entity;

namespace Venda.Repositorio.Mapping
{
    public class VendaItemMap : EntityTypeConfiguration<VendaItem>
    {
        public VendaItemMap()
        {
            ToTable("VendaItem", "Vendas");

            // Primary Key
            HasKey(t => new { t.VendaId, t.Id });

            // Properties
            Property(t => t.VendaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.VendaId).HasColumnName("VendaId");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            Property(t => t.Preco).HasColumnName("Preco");
            Property(t => t.Quantidadel).HasColumnName("Quantidadel");
            Property(t => t.SubTotal).HasColumnName("SubTotal");
            Property(t => t.Desconto).HasColumnName("Desconto");
            Property(t => t.Total).HasColumnName("Total");

            // Relationships
            HasRequired(t => t.Produto)
                .WithMany()
                .HasForeignKey(d => d.ProdutoId);

            HasRequired(t => t.Venda)
                .WithMany(t => t.Itens)
                .HasForeignKey(d => d.VendaId);
        }
    }
}
