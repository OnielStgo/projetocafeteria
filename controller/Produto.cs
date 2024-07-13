using Model;

namespace Controller {
    public class ControllerProduto {

        public static List<Produto> Sincronizar() {
            return Produto.Sincronizar();
        }
        public static void CriarProduto(
            string codigo,
            string descricao,
            decimal preco
        ) {
            new Produto(
                codigo,
                descricao,
                preco
            );
        }

        public static List<Produto> ListarProduto() {
            return Produto.ListarProduto();
        }

        public static void AlterarProduto(
            int indice,
            string codigo,
            string descricao,
            decimal preco
        ) {
            List<Produto> pessoas = ListarProduto();
            if(indice >= 0 && indice < pessoas.Count){
                Produto.AlterarProduto(
                    indice,
                    codigo,
                    descricao,
                    preco
                );
                Console.WriteLine("Produto alterado com sucesso");
            } else {
                Console.WriteLine("Indice inválido");
            }
        }

        public static void DeletarProduto(int indice) {
            List<Produto> produtos = ListarProduto();

            if(indice >= 0 && indice < produtos.Count){
                Produto.DeletarProduto(indice);
            } else {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}