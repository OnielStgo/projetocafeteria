using Model;
using MySqlConnector;

namespace Repo {
    public class ListFuncionario {
        static public List<Funcionario> funcionarios = new List<Funcionario>();
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
        public static Funcionario? GetFuncionario(int index){
            if(index < 0 || index >= funcionarios.Count){
                return null;
            }else {
                return funcionarios[index];
            }
        }

        public static List<Funcionario> Sincronizar() {
            funcionarios.Clear();
            InitConexao();

            string query = "SELECT * FROM funcionario";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Funcionario funcionario = new Funcionario();
                funcionario.IdFuncionario = Convert.ToInt32(reader["idFuncionario"].ToString());
                funcionario.Nome = reader["nome"].ToString() ?? "";
                funcionario.Idade = reader["idade"].ToString() ?? "";
                funcionario.Cpf = reader["cpf"].ToString()?? "";
                funcionario.Telefone = reader["telefone"].ToString()?? "";
                funcionarios.Add(funcionario);
            }

            CloseConexao();
            return funcionarios;
        }

        public static void Criar(Funcionario funcionario) {
            InitConexao();

            string insert = "INSERT INTO funcionario (nome, idade, cpf, telefone) VALUES (@Nome, @Idade, @Cpf, @Telefone)";
            MySqlCommand command = new MySqlCommand(insert, conexao);

            try {
                if(funcionario.Nome == null || funcionario.Idade == null || funcionario.Cpf == null || funcionario.Telefone == null) {
                    MessageBox.Show("Não foi possível adicionar o funcionário, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@Idade", funcionario.Idade);
                    command.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
                    command.Parameters.AddWithValue("@Telefone", funcionario.Telefone);

                    int rowsAffected = command.ExecuteNonQuery();
                    funcionario.IdFuncionario = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Funcionario cadastrado com sucesso");
                        funcionarios.Add(funcionario);
                    } else {
                        MessageBox.Show("Não foi possível adicionar o funcionario");
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
            string nome,
            string idade,
            string cpf,
            string telefone
        ){
            InitConexao();
            string query = "UPDATE funcionario SET nome = @Nome, idade = @Idade, cpf = @Cpf, telefone = @Telefone WHERE idFuncionario = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Funcionario funcionario = funcionarios[index];

            try {
                 if(nome == null || idade == null || cpf == null || telefone == null) {
                    MessageBox.Show("Não foi possível atualizar os dados, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Id", funcionario.IdFuncionario);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Idade", idade);
                    command.Parameters.AddWithValue("@Cpf", cpf);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    int rowsAffected = command.ExecuteNonQuery();
                
                    if (rowsAffected > 0) {
                        funcionarios[index].Nome = nome;
                        funcionarios[index].Idade = idade;
                        funcionarios[index].Cpf = cpf;
                        funcionarios[index].Telefone = telefone;
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
            // MessageBox.Show("Oi desde o delete do repo");
            InitConexao();
            string delete = "DELETE FROM funcionario WHERE idFuncionario = @IdFuncionario";
            MySqlCommand command = new MySqlCommand(delete, conexao);

            try
            {
                command.Parameters.AddWithValue("@IdFuncionario", GetFuncionario(index).IdFuncionario);
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) {
                    funcionarios.RemoveAt(index);
                    MessageBox.Show("Funcionario deletado com sucesso.");
                } else {
                    MessageBox.Show("Funcionario não encontrado.");
                }
                CloseConexao();
            }
            catch (Exception)
            {                
                MessageBox.Show("Para deletar um funcionário você deve selecionar o registro completo");
            }
        }
    }
}