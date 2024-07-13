using Repo;

namespace Model {
    public class Produto {
        public int IdProduto { get; set; }
        public string Codigo { set; get; }
        public string Descricao { set; get; }
        public decimal Preco { set; get; }

        public Produto() {}

        public Produto(string codigo, string descricao, decimal preco) {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            ListProduto.Criar(this);
        }

        public static List<Produto> Sincronizar() {
            return ListProduto.Sincronizar();
        }

        public static List<Produto> ListarProduto() {
            return ListProduto.produtos;
        }

        public static void AlterarProduto(
            int indice,
            string codigo,
            string descricao,
            decimal preco
        ){  
            ListProduto.Update(indice, codigo, descricao, preco);
        }

        public static void DeletarProduto(int indice) {
            ListProduto.Delete(indice);
        }
    }
}