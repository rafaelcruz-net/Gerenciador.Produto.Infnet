using System.Collections.Generic;

namespace Gerenciador.Produto.Repository
{
    public interface IProdutoRepository
    {
        void DeleteProduto(int idProduto);
        List<Domain.Produto> GetAll();
        Domain.Produto GetProdutoById(int idProduto);
        void InsertProduto(Domain.Produto produto);
        void UpdateProduto(Domain.Produto produto, int idProduto);
    }
}