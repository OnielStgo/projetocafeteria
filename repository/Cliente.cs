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









/*

using Model;
using MySqlConnector;

namespace Repo {
    public clroListCliente {
        static public List<Pessoa> pessoas = new List<Pessoa>();
        static private MySqlConnection conexao;
        public static void InitConexao() {
            string info = "server=localhost;database=projetointegrador2;user id=root;password='L31n0/*+-'";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Não deu, foi mal");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
        public static Pessoa? GetPessoa(int index){
            if(index < 0 || index >= pessoas.Count){
                return null;
            }else {
                return pessoas[index];
            }
        }

        public static List<Pessoa> Sincronizar() {
            // inicializa a conexão com o banco
            InitConexao();
            string query = "SELECT * FROM tarefas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(reader["id"].ToString());
                pessoa.Titulo = reader["titulo"].ToString() ?? "";
                pessoa.Data = reader["data"].ToString() ?? "";
                pessoa.Hora = reader["hora"].ToString() ?? "";
                pessoa.Concluida = reader["concluida"].ToString() ?? "";
                pessoas.Add(pessoa);
            }
            // fcha a conexão com o banco
            CloseConexao();
            return pessoas;
        }

        public static void Criar(Pessoa pessoa) {
            InitConexao();
            string insert = "INSERT INTO tarefas (titulo, data, hora, concluida) VALUES (@Titulo, @Data, @Hora, @Concluida)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if(pessoa.Titulo == null || pessoa.Data == null || pessoa.Hora == null || pessoa.Concluida == null) {
                    MessageBox.Show("Deu ruim, favor preencher a pessoa");
                } else {
                    command.Parameters.AddWithValue("@Titulo", pessoa.Titulo);
                    command.Parameters.AddWithValue("@Data", pessoa.Data);
                    command.Parameters.AddWithValue("@Hora", pessoa.Hora);
                    command.Parameters.AddWithValue("@Concluida", pessoa.Concluida);

                    int rowsAffected = command.ExecuteNonQuery();
                    pessoa.Id = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Tarefa cadastrada com sucesso");
                        pessoas.Add(pessoa);
                    } else {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("Deu ruim: " + e.Message);
            }
            // Executar a query


            CloseConexao();
        }

        public static void Update(
            int index,
            string titulo,
            string data,
            string hora,
            string concluida
        ){
            InitConexao();
            string query = "UPDATE tarefas SET titulo = @Titulo, data = @Data, hora = @Hora, concluida = @Concluida WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Pessoa pessoa = pessoas[index];
            try {
                 if(titulo == null || data == null || hora == null || concluida == null) {
                    MessageBox.Show("Deu ruim, favor preencher a tarefa");
                } else {
                    command.Parameters.AddWithValue("@Id", pessoa.Id);
                    command.Parameters.AddWithValue("@Titulo", titulo);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Hora", hora);
                    command.Parameters.AddWithValue("@Concluida", concluida);
                    int rowsAffected = command.ExecuteNonQuery();
                
                    if (rowsAffected > 0) {
                        pessoas[index].Titulo = titulo;
                        pessoas[index].Data = data;
                        pessoas[index].Hora = hora;
                        pessoas[index].Concluida = concluida;
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
            string delete = "DELETE FROM tarefas WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@Id", GetPessoa(index).Id);
            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0) {
                pessoas.RemoveAt(index);
                MessageBox.Show("Tarefa deletada com sucesso.");
            } else {
                MessageBox.Show("Tarefa não encontrado.");
            }
            CloseConexao();
        }

    }

}

*/