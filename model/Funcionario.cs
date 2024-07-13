using Repo;

namespace Model {
    public class Funcionario {
        public int IdFuncionario { get; set; }
        public string Nome { set; get; }
        public string Idade { set; get; }
        public string Cpf { set; get; }
        public string Telefone { set; get; }

        public Funcionario() {}

        public Funcionario(string nome, string idade, string cpf, string telefone) {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Telefone = telefone;
            ListFuncionario.Criar(this);
        }

        public static List<Funcionario> Sincronizar() {
            return ListFuncionario.Sincronizar();
        }

        public static List<Funcionario> ListarFuncionario() {
            return ListFuncionario.funcionarios;
        }

        public static void AlterarFuncionario(
            int indice,
            string nome,
            string idade,
            string cpf,
            string telefone
        ){  
            ListFuncionario.Update(indice, nome, idade, cpf, telefone);
        }

        public static void DeletarFuncionario(int indice) {
            ListFuncionario.Delete(indice);
        }
    }
}