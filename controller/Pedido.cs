using Model;

namespace Controller {
    public class ControllerPedido {

        public static List<Pedido> Sincronizar() {
            return Pedido.Sincronizar();
        }
        public static void CriarPedido(
            int idCliente,
            int idFuncionario,
            decimal total,
            List<ProdutosDoPedido> produtosDoPedido

        ) {
            new Pedido(
                idCliente,
                idFuncionario,
                total,
                produtosDoPedido
            );
        }

        public static List<Pedido> ListarPedido() {
            return Pedido.ListarPedido();
        }
    }
}