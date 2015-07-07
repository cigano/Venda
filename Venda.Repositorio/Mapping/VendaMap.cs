using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Venda.Repositorio.Mapping
{
    public class VendaMap : EntityTypeConfiguration<Entity.Venda>
    {
        public VendaMap()
        {
            ToTable("Venda", "Vendas");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataVenda).HasColumnName("DataVenda");
            Property(t => t.SubTotal).HasColumnName("SubTotal");
            Property(t => t.Desconto).HasColumnName("Desconto");
            Property(t => t.Total).HasColumnName("Total");
        }
    }
}
