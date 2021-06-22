using System;

namespace Gerenciador.Produto.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public Decimal Preco { get; set; }
    }
}
