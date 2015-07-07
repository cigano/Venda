using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MySql.Data.Entity;
using Venda.Repositorio.Entity;
using Venda.Repositorio.Mapping;

namespace Venda.Repositorio.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class VendasContext : DbContext
    {
        public VendasContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public VendasContext()
            : base("Name=VendasContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Entity.Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new VendaMap());
            modelBuilder.Configurations.Add(new VendaItemMap());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MigrationsContextFactory : IDbContextFactory<VendasContext>
    {
        public VendasContext Create()
        {
            return new VendasContext("VendasContext");
        }
    }
}
