namespace Venda.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Produto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 45, unicode: false),
                        Unidade = c.String(nullable: false, maxLength: 5, unicode: false),
                        Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "VendaItem",
                c => new
                    {
                        VendaId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Quantidadel = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Desconto = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.VendaId, t.Id })                ;
            
            CreateTable(
                "Venda",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataVenda = c.DateTime(nullable: false, precision: 0),
                        SubTotal = c.Double(nullable: false),
                        Desconto = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
        
        public override void Down()
        {
            DropForeignKey("Vendas.VendaItem", "VendaId", "Vendas.Venda");
            DropForeignKey("Vendas.VendaItem", "ProdutoId", "Vendas.Produto");
            DropIndex("Vendas.VendaItem", new[] { "ProdutoId" });
            DropIndex("Vendas.VendaItem", new[] { "VendaId" });
            DropTable("Vendas.Venda");
            DropTable("Vendas.VendaItem");
            DropTable("Vendas.Produto");
        }
    }
}
