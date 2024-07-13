using Repo;

namespace Model {
    public class PedidoProduto {
        public int IdPed_Prod { set; get; }
        public int IdPedido { set; get; }
        public int IdProduto { set; get; }
        public int Quantidade { set; get; }
        public decimal Total { set; get; }

        public PedidoProduto() {}

        public PedidoProduto(int idPedido, int idproduto, int quantidade, decimal total) {
            IdPedido = idPedido;
            IdProduto = idproduto;
            Quantidade = quantidade;
            Total = total;            
        }

        public static List<PedidoProduto>  ObterDetalhesDeUmPedido(int idPedido){
            return ListPedidoProduto.ObterDetalhesDeUmPedido(idPedido);
        }
    }
}