using Model;

namespace Controller {
    public class ControllerPedidoProduto {

        // public static List<Pedido> Sincronizar() {
        //     return Pedido.Sincronizar();
        // }
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


        // public static List<Pedido> ListarPedido() {
        //     return Pedido.ListarPedido();
        // }

        

        // public static void AlterarPedido(
        //     int indice,
        //     string idPedido,
        //     string idProduto,
        //     string cpf,
        //     string telefone
        // ) {
        //     List<Pedido> funcionarios = ListarPedido();
        //     if(indice >= 0 && indice < funcionarios.Count){
        //         Pedido.AlterarPedido(
        //             indice,
        //             idPedido,
        //             idProduto,
        //             cpf,
        //             telefone
        //         );
        //         Console.WriteLine("Pedido alterado com sucesso");
        //     } else {
        //         Console.WriteLine("Indice inválido");
        //     }
        // }

        // public static void DeletarPedido(int indice) {
        //     // MessageBox.Show("Oi desde o DeletarPedido do controller");
        //     List<Pedido> funcionarios = ListarPedido();

        //     if(indice >= 0 && indice < funcionarios.Count){
        //         Pedido.DeletarPedido(indice);
        //     } else {
        //         Console.WriteLine("Indice inválido");
        //     }
        // }
    }
}