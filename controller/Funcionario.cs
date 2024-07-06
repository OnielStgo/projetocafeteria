using Model;

namespace Controller {
    public class ControllerFuncionario {

        public static List<Funcionario> Sincronizar() {
            return Funcionario.Sincronizar();
        }
        public static void CriarFuncionario(
            string nome,
            string idade,
            string cpf,
            string telefone
        ) {
            new Funcionario(
                nome,
                idade,
                cpf,
                telefone
            );
        }

        public static List<Funcionario> ListarFuncionario() {
            return Funcionario.ListarFuncionario();
        }

        public static void AlterarFuncionario(
            int indice,
            string nome,
            string idade,
            string cpf,
            string telefone
        ) {
            List<Funcionario> funcionarios = ListarFuncionario();
            if(indice >= 0 && indice < funcionarios.Count){
                Funcionario.AlterarFuncionario(
                    indice,
                    nome,
                    idade,
                    cpf,
                    telefone
                );
                Console.WriteLine("Funcionario alterado com sucesso");
            } else {
                Console.WriteLine("Indice inválido");
            }
        }

        public static void DeletarFuncionario(int indice) {
            // MessageBox.Show("Oi desde o DeletarFuncionario do controller");
            List<Funcionario> funcionarios = ListarFuncionario();

            if(indice >= 0 && indice < funcionarios.Count){
                Funcionario.DeletarFuncionario(indice);
            } else {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}