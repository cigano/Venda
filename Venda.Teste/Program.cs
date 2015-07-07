using System;
using System.Linq;
using Venda.Repositorio.Context;
using Venda.Repositorio.Entity;

namespace Venda.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new VendasContext())
            {
                ctx.Produtos.Add(new Produto
                {
                    Id = 1,
                    Descricao = "Tomate",
                    Unidade = "KG",
                    Preco = 0.78
                });

                ctx.Produtos.Add(new Produto
                {
                    Id = 1,
                    Descricao = "Batata",
                    Unidade = "KG",
                    Preco = 0.38
                });
            }

            using (var ctx = new VendasContext())
            {
                var produtos = ctx.Produtos.OrderBy(p => p.Descricao);
                foreach (var produto in produtos)
                    Console.WriteLine("Produto {0} - {1}", produto.Id, produto.Descricao);
            }

            Console.WriteLine();
            Console.WriteLine("Fim do processo");
            Console.ReadLine();
        }
    }
}
