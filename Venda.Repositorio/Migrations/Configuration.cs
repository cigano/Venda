using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using MySql.Data.Entity;
using Venda.Repositorio.Context;
using System.Data.Entity.Migrations.Utilities;
using System.Collections.Generic;
using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.Resources;
using System.Data.Entity.Spatial;
using System.Data.Entity.Utilities;
using System.Linq;
using System.Data.Entity.Migrations.Design;

namespace Venda.Repositorio.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VendasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new CustomMySqlMigrationSqlGenerator());
            CodeGenerator = new CustomMySqlMigrationCodeGenerator();
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }

    public class CustomMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        protected override MigrationStatement Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.PrincipalTable = addForeignKeyOperation.PrincipalTable.Replace("Vendas.", "");
            addForeignKeyOperation.DependentTable = addForeignKeyOperation.DependentTable.Replace("Vendas.", "");
            return base.Generate(addForeignKeyOperation);
        }
    }

    public class CustomMySqlMigrationCodeGenerator : MySqlMigrationCodeGenerator
    {
        protected override void Generate(CreateTableOperation createTableOperation, IndentedTextWriter writer)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            var create = new CreateTableOperation(createTableOperation.Name.Replace("Vendas.", ""));

            foreach (var item in createTableOperation.Columns)
                create.Columns.Add(item);

            create.PrimaryKey = createTableOperation.PrimaryKey;

            base.Generate(create, writer);
        }
    }
}
