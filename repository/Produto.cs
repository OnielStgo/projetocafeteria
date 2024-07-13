using Model;
using MySqlConnector;

namespace Repo {
    public class ListProduto {
        static public List<Produto> produtos = new List<Produto>();
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
        public static Produto? GetProduto(int index){
            if(index < 0 || index >= produtos.Count){
                return null;
            }else {
                return produtos[index];
            }
        }

        public static List<Produto> Sincronizar() {
            produtos.Clear();
            // inicializa a conexão com o banco
            InitConexao();
            string query = "SELECT * FROM produto";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            // MessageBox.Show("oi");
            while (reader.Read()) {
                Produto produto = new Produto();
                produto.IdProduto = Convert.ToInt32(reader["idProduto"].ToString());
                produto.Codigo = reader["codigo"].ToString() ?? "";
                produto.Descricao = reader["descricao"].ToString() ?? "";
                produto.Preco = Convert.ToDecimal(reader["preco"].ToString());
                produtos.Add(produto);
            }
            // fcha a conexão com o banco
            CloseConexao();
            return produtos;
        }

        public static void Criar(Produto produto) {
            InitConexao();
            string insert = "INSERT INTO produto (codigo, descricao, preco) VALUES (@Codigo, @Descricao, @Preco)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if(produto.Codigo == null || produto.Descricao == null || produto.Preco == 0) {
                    MessageBox.Show("Não foi possível adicionar o produto, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Codigo", produto.Codigo);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);

                    int rowsAffected = command.ExecuteNonQuery();
                    produto.IdProduto = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Produto cadastrado com sucesso");
                        produtos.Add(produto);
                    } else {
                        MessageBox.Show("Não foi possível adicionar o produto");
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
            string codigo,
            string descricao,
            decimal preco
        ){
            InitConexao();
            string query = "UPDATE produto SET codigo = @Codigo, descricao = @Descricao, preco = @Preco WHERE idProduto = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Produto produto = produtos[index];
            try {
                 if(codigo == null || descricao == null || preco == 0) {
                    MessageBox.Show("Não foi possível atualizar os dados, favor preencher os campos corretamente e tentar outra vez");
                } else {
                    command.Parameters.AddWithValue("@Id", produto.IdProduto);
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Descricao", descricao);
                    command.Parameters.AddWithValue("@Preco", preco);
                    int rowsAffected = command.ExecuteNonQuery();
                
                    if (rowsAffected > 0) {
                        produtos[index].Codigo = codigo;
                        produtos[index].Descricao = descricao;
                        produtos[index].Preco = preco;
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
            string delete = "DELETE FROM produto WHERE idProduto = @IdProduto";
            MySqlCommand command = new MySqlCommand(delete, conexao);

            try
            {
                command.Parameters.AddWithValue("@IdProduto", GetProduto(index).IdProduto);
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) {
                    produtos.RemoveAt(index);
                    MessageBox.Show("Produto deletado com sucesso.");
                } else {
                    MessageBox.Show("Produto não encontrado.");
                }
                CloseConexao();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Para deletar um produto você deve selecionar o registro completo");
            }


            // command.Parameters.AddWithValue("@IdProduto", GetProduto(index).IdProduto);
            // int rowsAffected = command.ExecuteNonQuery();
            // if(rowsAffected > 0) {
            //     produtos.RemoveAt(index);
            //     MessageBox.Show("Produto deletado com sucesso.");
            // } else {
            //     MessageBox.Show("Produto não encontrado.");
            // }
            // CloseConexao();
        }

    }

}









/*

using Model;
using MySqlConnector;

namespace Repo {
    public clroListProduto {
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