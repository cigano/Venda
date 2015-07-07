using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Venda.Repositorio.Entity;

namespace Venda.Repositorio.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto", "Vendas");
            
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(45);

            Property(t => t.Unidade)
                .IsRequired()
                .HasMaxLength(5);

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Unidade).HasColumnName("Unidade");
            Property(t => t.Preco).HasColumnName("Preco");
        }
    }
}
