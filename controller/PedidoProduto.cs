using Model;

namespace Controller {
    public class ControllerPedidoProduto {

        public static void CriarPedidoProduto(
            int idPedido,
            int idProduto,
            int quantidade,
            decimal total
        ) {
            new PedidoProduto(
                idPedido,
                idProduto,
                quantidade,
                total
            );
        }

        public static List<PedidoProduto>  ObterDetalhesDeUmPedido(int idPedido){
            return PedidoProduto.ObterDetalhesDeUmPedido(idPedido);
        }
    }
}