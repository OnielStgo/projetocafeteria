using Model;
using MySqlConnector;

namespace Repo {
    public class ListPedidoProduto {
        static public List<PedidoProduto> pedidoprodutos = new List<PedidoProduto>();
        static private MySqlConnection conexao;
        public static void InitConexao() {
            // string info = "server=localhost;database=projetocafeteria;user id=root;password='';allow_user_variables=True";
            string info = "server=localhost;database=projetocafeteria;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Aconteceu um erro ao tentar conectar com a base de dadosssssssss");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
        public static PedidoProduto? GetPedidoProduto(int index){
            if(index < 0 || index >= pedidoprodutos.Count){
                return null;
            }else {
                return pedidoprodutos[index];
            }
        }
        // public static List<PedidoProduto> ObterDetalhesDeUmPedido(int idPedido) {

        //     InitConexao();
        //     string query = "SELECT * FROM pedido_produto WHERE idPedido=@IdPedido";
        //     MySqlCommand command = new MySqlCommand(query, conexao);
        //     command.Parameters.AddWithValue("@IdPedido", idPedido);
        //     MySqlDataReader reader = command.ExecuteReader();

        //     while (reader.Read()) {
        //         PedidoProduto pedidoproduto = new PedidoProduto();
        //         pedidoproduto.IdPed_Prod = Convert.ToInt32(reader["idPed_Prod"].ToString());
        //         pedidoproduto.IdPedido = Convert.ToInt32(reader["idPedido"].ToString() ?? "");
        //         pedidoproduto.IdProduto = Convert.ToInt32(reader["idProduto"].ToString() ?? "");
        //         pedidoproduto.Quantidade = Convert.ToInt32(reader["quantidade"].ToString()?? "");
        //         pedidoproduto.Total = Convert.ToDecimal(reader["total"].ToString()?? "");

        //         pedidoprodutos.Add(pedidoproduto);
        //     }

        //     CloseConexao();
        //     return pedidoprodutos;
        // }



        public static List<PedidoProduto> ObterDetalhesDeUmPedido(int idPedido) {
            pedidoprodutos.Clear();
            InitConexao();
            if (conexao.State == System.Data.ConnectionState.Open) {
                string query = "SELECT * FROM pedido_produto WHERE idPedido=@IdPedido";
                MySqlCommand command = new MySqlCommand(query, conexao);
                // Definindo o parâmetro @IdPedido
                command.Parameters.AddWithValue("@IdPedido", idPedido);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    PedidoProduto pedidoproduto = new PedidoProduto {
                        IdPed_Prod = Convert.ToInt32(reader["idPed_Prod"].ToString()),
                        IdPedido = Convert.ToInt32(reader["idPedido"].ToString() ?? ""),
                        IdProduto = Convert.ToInt32(reader["idProduto"].ToString() ?? ""),
                        Quantidade = Convert.ToInt32(reader["quantidade"].ToString() ?? ""),
                        Total = Convert.ToDecimal(reader["total"].ToString() ?? "")
                    };

                    pedidoprodutos.Add(pedidoproduto);
                }

                reader.Close();
            } else {
                MessageBox.Show("Não foi possível abrir a conexão com o banco de dados.");
            }
            CloseConexao();
            return pedidoprodutos;
        }
        
    }
}









/*

using Model;
using MySqlConnector;

namespace Repo {
    public clroPedidoProduto {
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