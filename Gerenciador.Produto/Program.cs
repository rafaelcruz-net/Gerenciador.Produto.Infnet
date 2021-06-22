using Gerenciador.Produto.Repository;
using Newtonsoft.Json;
using System;

namespace Gerenciador.Produto
{
    class Program
    {
        private static IProdutoRepository Repository = new ProdutoRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("============== Gerenciador de Produto ===========");
            Console.WriteLine("=================================================");

            var sair = false;

            while (!sair)
            {
                ExibeOpções();
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        CadastroProduto();
                        break;
                    case "2":
                        AtualizarProduto();
                        break;
                    case "3":
                        ExcluirProduto();
                        break;
                    case "4":
                        ObterProduto();
                        break;
                    case "5":
                        ListarTodosProduto();
                        break;
                    case "q":
                        Console.WriteLine("Até Logo :)");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }

            }
        }

        private static void ListarTodosProduto()
        {
            Console.WriteLine("Exibindo Todos os Produtos");
            Console.WriteLine("");
            var produtos = Repository.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(produtos, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ObterProduto()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do produto");

            var id = Convert.ToInt32(Console.ReadLine());
            var produto = Repository.GetProdutoById(id);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo produto com o identificador {id}");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(produto, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ExcluirProduto()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do produto para realizar a exclusão");

            var id = Convert.ToInt32(Console.ReadLine());

            var produto = Repository.GetProdutoById(id);

            if (produto == null)
                Console.WriteLine("Produto não encontrado");
            else
            {
                Repository.DeleteProduto(id);
                Console.WriteLine("Produto excluido com sucesso");
            }
        }

        private static void AtualizarProduto()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do produto");

            var id = Convert.ToInt32(Console.ReadLine());
            var produto = Repository.GetProdutoById(id);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
            }
            else
            {
                Console.WriteLine("Informe o nome do Produto");
                produto.Nome = Console.ReadLine();

                Console.WriteLine("Informe a Descricao do Produto");
                produto.Descricao = Console.ReadLine();

                Console.WriteLine("Informe quantidade do Produto em estoque");
                produto.QuantidadeEmEstoque = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe Preco do Produto");
                produto.Preco = Convert.ToDecimal(Console.ReadLine());

                Repository.UpdateProduto(produto, id);

                Console.WriteLine("Produto atualizado com sucesso!");
            }
        }

        private static void CadastroProduto()
        {
            var produto = new Domain.Produto();

            Console.WriteLine("Informe o nome do produto");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("Informe a descricao do produto");
            produto.Descricao = Console.ReadLine();

            Console.WriteLine("Informe o quantidade em estoque do produto");
            produto.QuantidadeEmEstoque = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o preco do produto");
            produto.Preco = Convert.ToDecimal(Console.ReadLine());

            Repository.InsertProduto(produto);

            Console.WriteLine("Cadastro Realizado com sucesso!");
        }

        private static void ExibeOpções()
        {
            Console.WriteLine("Selecione as opções");
            Console.WriteLine("1 - Para criar um Produto");
            Console.WriteLine("2 - Para atualizar um Produto");
            Console.WriteLine("3 - Para excluir um Produto");
            Console.WriteLine("4 - Para obter um Produto");
            Console.WriteLine("5 - Para exibir todos os Produto");
            Console.WriteLine("q - Para sair");
        }
    }
}
