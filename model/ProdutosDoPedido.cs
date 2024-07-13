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

            // MessageBox.Show(typeof(idCliente) );
            
            // ListPedido.Criar(this);
        }

        public static List<ProdutosDoPedido> ObterProdutosDoPedido() {
          return ListProdutosDoPedido.produtosDoPedido;
        }



        // public static List<Pedido> Sincronizar() {
        //     return ListPedido.Sincronizar();
        // }

        // public static List<Pedido> ListarPedido() {
        //     return ListPedido.pedidos;
        // }





        // public static void AlterarPedido(
        //     int indice,
        //     string idCliente,
        //     string idFuncionario,
        //     string cpf,
        //     string Total
        // ){  
        //     ListPedido.Update(indice, idCliente, idFuncionario, cpf, Total);
        // }

        // public static void DeletarPedido(int indice) {
        //     ListPedido.Delete(indice);
        // }

    }
}
