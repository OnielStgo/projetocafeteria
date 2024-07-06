using Model;

namespace Controller {
    public class ControllerCliente {

        public static List<Cliente> Sincronizar() {
            return Cliente.Sincronizar();
        }
        public static void CriarCliente(
            string nome,
            string idade,
            string cpf,
            string telefone
        ) {
            new Cliente(
                nome,
                idade,
                cpf,
                telefone
            );
        }

        public static List<Cliente> ListarCliente() {
            return Cliente.ListarCliente();
        }

        public static void AlterarCliente(
            int indice,
            string nome,
            string idade,
            string cpf,
            string telefone
        ) {
            List<Cliente> clientes = ListarCliente();
            if(indice >= 0 && indice < clientes.Count){
                Cliente.AlterarCliente(
                    indice,
                    nome,
                    idade,
                    cpf,
                    telefone
                );
                Console.WriteLine("Cliente alterado com sucesso");
            } else {
                Console.WriteLine("Indice inválido");
            }
        }

        public static void DeletarCliente(int indice) {
            // MessageBox.Show("Oi desde o DeletarCliente do controller");
            List<Cliente> clientes = ListarCliente();

            if(indice >= 0 && indice < clientes.Count){
                Cliente.DeletarCliente(indice);
            } else {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}