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










/*
using Model;

namespace Controller {
    public class ControllerPrCriarProduto {

        public static List<Pessoa> Sincronizar() {
            return Pessoa.Sincronizar();
        }
        public static void CriarPessoa(
            string titulo,
            string data,
            string hora,
            string concluida
        ) {
            // validade cpf, validar idade
            new Pessoa(
                titulo,
                data,
                hora
            );
        }

        public static List<Pessoa> ListarPessoa() {
            return Pessoa.ListarPessoa();
        }

        public static void AlterarPessoa(
            int indice,
            string titulo,
            string data,
            string hora,
            string concluida
        ) {
            List<Pessoa> pessoas = ListarPessoa();
            if(indice >= 0 && indice < pessoas.Count){
                Pessoa.AlterarPessoa(
                    indice,
                    titulo,
                    data,
                    hora,
                    concluida
                );
                Console.WriteLine("Pessoa alterada com sucesso");
            } else {
                Console.WriteLine("Indice inválido");
            }
        }

        public static void DeletarPessoa(int indice) {
            List<Pessoa> pessoas = ListarPessoa();

            if(indice >= 0 && indice < pessoas.Count){
                Pessoa.DeletarPessoa(indice);
            } else {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}

*/