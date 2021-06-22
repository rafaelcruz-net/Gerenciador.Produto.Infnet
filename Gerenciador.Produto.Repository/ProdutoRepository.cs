using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gerenciador.Produto.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GerenciadorProdutoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Domain.Produto> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAllProduct";

                return connection
                        .Query<Domain.Produto>(sql, commandType: System.Data.CommandType.StoredProcedure)
                        .AsList();
            }
        }

        public Domain.Produto GetProdutoById(int idProduto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectProductById";

                return connection
                        .QueryFirstOrDefault<Domain.Produto>(sql,
                            new { IdProduct = idProduto },
                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteProduto(int idProduto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.DeleteProduct";
                connection.Execute(sql, new { IdProduct = idProduto }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void InsertProduto(Domain.Produto produto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.InsertProduct";
                connection.Execute(sql,
                                   new
                                   {
                                       Nome = produto.Nome,
                                       Descricao = produto.Descricao,
                                       QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                                       Preco = produto.Preco
                                   },
                                   commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateProduto(Domain.Produto produto, int idProduto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.UpdateProduct";
                connection.Execute(sql,
                                   new
                                   {
                                       Nome = produto.Nome,
                                       Descricao = produto.Descricao,
                                       QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                                       Preco = produto.Preco,
                                       idProduct = idProduto
                                   },
                                   commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
