using Model;
using MySqlConnector;

namespace Repo {
    public class ListCliente {
        static public List<Cliente> clientes = new List<Cliente>();
        static private MySqlConnection conexao;
        public static void InitConexao() {
            string info = "server=localhost;database=projetocafeteria;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Aconteceu um erro ao tentar conectar com a base de dados");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
        public static Cliente? GetCliente(int index){
            if(index < 0 || index >= clientes.Count){
                return null;
            }else {
                return clientes[index];
            }
        }
        public static List<Cliente> Sincronizar() {
            clientes.Clear();

            InitConexao();
            string query = "SELECT * FROM cliente";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(reader["idCliente"].ToString());
                cliente.Nome = reader["nome"].ToString() ?? "";
                cliente.Idade = reader["idade"].ToString() ?? "";
                cliente.Cpf = reader["cpf"].ToString()?? "";
                cliente.Telefone = reader["telefone"].ToString()?? "";
                clientes.Add(cliente);
            }

            CloseConexao();
            return clientes;
        }

        public static void Criar(Cliente cliente) {
            InitConexao();
            string insert = "INSERT INTO cliente (nome, idade, cpf, telefone) VALUES (@Nome, @Idade, @Cpf, @Telefone)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if(cliente.Nome == null || cliente.Idade == null || cliente.Cpf == null || cliente.Telefone == null) {
                    MessageBox.Show("Não foi possível adicionar o cliente, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Idade", cliente.Idade);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone);

                    int rowsAffected = command.ExecuteNonQuery();
                    cliente.IdCliente = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Cliente cadastrado com sucesso");
                        clientes.Add(cliente);
                    } else {
                        MessageBox.Show("Não foi possível adicionar o cliente");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("Erro durante a execução do comando: " + e.Message);
            }

            CloseConexao();
        }

        public static void Update(
            int index,
            string nome,
            string idade,
            string cpf,
            string telefone
        ){
            InitConexao();
            string query = "UPDATE cliente SET nome = @Nome, idade = @Idade, cpf = @Cpf, telefone = @Telefone WHERE idCliente = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Cliente cliente = clientes[index];
            try {
                 if(nome == null || idade == null || cpf == null || telefone == null) {
                    MessageBox.Show("Não foi possível atualizar os dados, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Id", cliente.IdCliente);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Idade", idade);
                    command.Parameters.AddWithValue("@Cpf", cpf);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    int rowsAffected = command.ExecuteNonQuery();
                
                    if (rowsAffected > 0) {
                        clientes[index].Nome = nome;
                        clientes[index].Idade = idade;
                        clientes[index].Cpf = cpf;
                        clientes[index].Telefone = telefone;
                    }
                    else {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                }
            }catch (Exception ex){
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();
        }

        public static void Delete(int index) {
            InitConexao();
            string delete = "DELETE FROM cliente WHERE idCliente = @IdCliente";
            MySqlCommand command = new MySqlCommand(delete, conexao);

            try
            {
                command.Parameters.AddWithValue("@IdCliente", GetCliente(index).IdCliente);
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) {
                    clientes.RemoveAt(index);
                    MessageBox.Show("Cliente deletado com sucesso.");
                } else {
                    MessageBox.Show("Cliente não encontrado.");
                }
                CloseConexao();
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Erro durante a execução do comando: " + e.Message);
            }
        }
    }
}