using Model;

namespace Controller {
    public class ControllerProdutosDoPedido {
        
        public static void CriarProdutosDoPedido(int idDoProduto, int qtde, decimal TotalDoProduto) {
            new ProdutosDoPedido(idDoProduto, qtde, TotalDoProduto);
        }

        public static List<ProdutosDoPedido> ObterProdutosDoPedido() {
            return ProdutosDoPedido.ObterProdutosDoPedido();
        }
    }
}