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
            // int IndiceProduto, 
            // int quantidade, 
            // decimal TotalDoProduto
            List<ProdutosDoPedido> produtosDoPedido

        ) {
            // MessageBox.Show("Oi desde o controller Pedido");

            new Pedido(
                idCliente,
                idFuncionario,
                total,
                // IndiceProduto, 
                // quantidade,
                // TotalDoProduto
                produtosDoPedido
            );
        }

        public static List<Pedido> ListarPedido() {
            return Pedido.ListarPedido();
        }

        // public static void AlterarPedido(
        //     int indice,
        //     string idCliente,
        //     string idFuncionario,
        //     string cpf,
        //     string telefone
        // ) {
        //     List<Pedido> funcionarios = ListarPedido();
        //     if(indice >= 0 && indice < funcionarios.Count){
        //         Pedido.AlterarPedido(
        //             indice,
        //             idCliente,
        //             idFuncionario,
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