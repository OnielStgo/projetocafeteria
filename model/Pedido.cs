using Repo;

namespace Model {
    public class Pedido {
        public int IdPedido { set; get; }
        public int IdCliente { set; get; }
        public int IdFuncionario { set; get; }
        public DateTime Data { set; get; }
        public decimal Total { set; get; }
        public int Quantidade { set; get; }
        public decimal TotalDoProduto { set; get; }
        ProdutosDoPedido produtosDoPedido;        

        public Pedido() {}

        public Pedido(int idCliente, int idFuncionario, decimal total, List<ProdutosDoPedido> produtosDoPedido) {
            IdCliente = idCliente;
            IdFuncionario = idFuncionario;
            Data = DateTime.Now;
            Total = total;
            
            ListPedido.Criar(this, produtosDoPedido);
        }

        public static List<Pedido> Sincronizar() {
            return ListPedido.Sincronizar();
        }

        public static List<Pedido> ListarPedido() {
            return ListPedido.pedidos;
        }
    }
}