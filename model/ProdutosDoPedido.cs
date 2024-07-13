using Repo;

namespace Model {
    public class ProdutosDoPedido {
        public int IdProduto { set; get; }
        public int QuantidadePorProduto { set; get; }
        public decimal TotalPorProduto { set; get; }

        public ProdutosDoPedido() {}

        public ProdutosDoPedido(int idProduto, int quantidadePorProduto, decimal totalPorProduto) {
            IdProduto = idProduto;
            QuantidadePorProduto = quantidadePorProduto;
            TotalPorProduto = totalPorProduto;

            ListProdutosDoPedido.produtosDoPedido.Add(this);
        }

        public static List<ProdutosDoPedido> ObterProdutosDoPedido() {
          return ListProdutosDoPedido.produtosDoPedido;
        }
    }
}
