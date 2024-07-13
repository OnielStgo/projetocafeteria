using Model;
using MySqlConnector;

namespace Repo {
    public class ListProdutosDoPedido {
        static public List<ProdutosDoPedido> produtosDoPedido = new List<ProdutosDoPedido>();





        // ///////////////////
        // public static void Criar(Pedido pedido, int IndiceProduto, int Quantidade, decimal TotalDoProduto)
        // {
        //     InitConexao();

        //     string insertPedido = "INSERT INTO pedido (idCliente, idFuncionario, data, total) VALUES (@IdCliente, @IdFuncionario, @Data, @Total)";
        //     MySqlCommand command = new MySqlCommand(insertPedido, conexao);

        //     try
        //     {
        //         // Validação de dados
        //         if (pedido.IdCliente < 0 || pedido.IdFuncionario < 0 || Convert.ToString(pedido.Data) == null || pedido.Total < 0)
        //         {
        //             MessageBox.Show("Não foi possível adicionar o pedido, favor preencher os campos corretamente e tentar outra vez.");
        //             return;
        //         }

        //         // Inserção na tabela pedido
        //         command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
        //         command.Parameters.AddWithValue("@IdFuncionario", pedido.IdFuncionario);
        //         command.Parameters.AddWithValue("@Data", pedido.Data);
        //         command.Parameters.AddWithValue("@Total", pedido.Total);

        //         int rowsAffected = command.ExecuteNonQuery();
        //         int ultimoId = Convert.ToInt32(command.LastInsertedId);

        //         if (rowsAffected > 0)
        //         {
        //             pedidos.Add(pedido);
        //             MessageBox.Show("Pedido salvo na tabela 'pedido'. Foi executado o 'INSERT INTO pedido' corretamente");

        //             string insertPedidoProduto = "INSERT INTO pedido_produto (idPedido, idProduto, quantidade, total) VALUES (@IdPedido, @IdProduto, @Quantidade, @TotalDoProduto)";
        //             MySqlCommand command2 = new MySqlCommand(insertPedidoProduto, conexao);

        //             // Validação de dados para pedido_produto
        //             if (ultimoId < 0 || IndiceProduto < 0 || Quantidade < 0 || TotalDoProduto < 0)
        //             {
        //                 MessageBox.Show("Não foi possível adicionar o pedido_produto, favor preencher os campos corretamente e tentar outra vez.");
        //                 return;
        //             }

        //             // Inserção na tabela pedido_produto
        //             command2.Parameters.AddWithValue("@IdPedido", ultimoId);
        //             command2.Parameters.AddWithValue("@IdProduto", IndiceProduto);
        //             command2.Parameters.AddWithValue("@Quantidade", Quantidade);
        //             command2.Parameters.AddWithValue("@TotalDoProduto", TotalDoProduto);

        //             int rowsAffected2 = command2.ExecuteNonQuery();

        //             if (rowsAffected2 > 0)
        //             {
        //                 MessageBox.Show("Registro salvo na tabela 'pedido_produto'. Foi executado o 'INSERT INTO pedido_produto' corretamente");
        //             }
        //             else
        //             {
        //                 MessageBox.Show("Não foi possível executar o 'INSERT INTO pedido_produto'");
        //             }
        //         }
        //         else
        //         {
        //             MessageBox.Show("Não foi possível adicionar o pedido na tabela pedido. Não foi executado o 'INSERT INTO pedido'");
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         MessageBox.Show("Erro: " + e.Message);
        //     }
        //     finally
        //     {
        //         CloseConexao();
        //     }
        // }
////////////////////////////
///

        // public static void Criar(Pedido pedido, int IndiceProduto, int Quantidade, decimal TotalDoProduto)
        // {

        //     string IndiceProdutoAsString = Convert.ToString(IndiceProduto);
        //     MessageBox.Show("O id do produto que chegou no repository é: " + IndiceProdutoAsString);

        //     string QuantidadeAsString = Convert.ToString(Quantidade);
        //     MessageBox.Show("O valor da Quantidade que chegou no repository é: " + QuantidadeAsString);

        //     string TotalDoProdutoAsString = Convert.ToString(TotalDoProduto);
        //     MessageBox.Show("O valor do TotalDoProduto que chegou no repository é: " + TotalDoProdutoAsString);





        //     InitConexao();

        //     string insertPedido = "INSERT INTO pedido (idCliente, idFuncionario, data, total) VALUES (@IdCliente, @IdFuncionario, @Data, @Total)";
        //     MySqlCommand command = new MySqlCommand(insertPedido, conexao);

        //     try
        //     {
        //         // Validação de dados
        //         if (pedido.IdCliente < 0 || pedido.IdFuncionario < 0 || Convert.ToString(pedido.Data) == null || pedido.Total < 0)
        //         {
        //             MessageBox.Show("Não foi possível adicionar o pedido, favor preencher os campos corretamente e tentar outra vez.");
        //             return;
        //         }

        //         // Inserção na tabela pedido
        //         command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
        //         command.Parameters.AddWithValue("@IdFuncionario", pedido.IdFuncionario);
        //         command.Parameters.AddWithValue("@Data", pedido.Data);
        //         command.Parameters.AddWithValue("@Total", pedido.Total);

        //         int rowsAffected = command.ExecuteNonQuery();
        //         int ultimoId = Convert.ToInt32(command.LastInsertedId);

        //         if (rowsAffected > 0)
        //         {
        //             pedidos.Add(pedido);
        //             MessageBox.Show("Pedido salvo na tabela 'pedido'. Foi executado o 'INSERT INTO pedido' corretamente");

        //             // Verifica se o produto existe
        //             string verificaProduto = "SELECT COUNT(*) FROM produto WHERE idProduto = @IdProduto";
        //             MySqlCommand verificaProdutoCommand = new MySqlCommand(verificaProduto, conexao);
        //             verificaProdutoCommand.Parameters.AddWithValue("@IdProduto", IndiceProduto);

        //             long produtoExiste = (long)verificaProdutoCommand.ExecuteScalar();

        //             if (produtoExiste == 0)
        //             {
        //                 MessageBox.Show("O produto com idProduto = " + IndiceProduto + " não existe na tabela 'produto'.");
        //                 return;
        //             }

        //             string insertPedidoProduto = "INSERT INTO pedido_produto (idPedido, idProduto, quantidade, total) VALUES (@IdPedido, @IdProduto, @Quantidade, @TotalDoProduto)";
        //             MySqlCommand command2 = new MySqlCommand(insertPedidoProduto, conexao);

        //             // Validação de dados para pedido_produto
        //             if (ultimoId < 0 || IndiceProduto < 0 || Quantidade < 0 || TotalDoProduto < 0)
        //             {
        //                 MessageBox.Show("Não foi possível adicionar o pedido_produto, favor preencher os campos corretamente e tentar outra vez.");
        //                 return;
        //             }

        //             // Inserção na tabela pedido_produto
        //             command2.Parameters.AddWithValue("@IdPedido", ultimoId);
        //             command2.Parameters.AddWithValue("@IdProduto", IndiceProduto);
        //             command2.Parameters.AddWithValue("@Quantidade", Quantidade);
        //             command2.Parameters.AddWithValue("@TotalDoProduto", TotalDoProduto);

        //             int rowsAffected2 = command2.ExecuteNonQuery();

        //             if (rowsAffected2 > 0)
        //             {
        //                 MessageBox.Show("Registro salvo na tabela 'pedido_produto'. Foi executado o 'INSERT INTO pedido_produto' corretamente");
        //             }
        //             else
        //             {
        //                 MessageBox.Show("Não foi possível executar o 'INSERT INTO pedido_produto'");
        //             }
        //         }
        //         else
        //         {
        //             MessageBox.Show("Não foi possível adicionar o pedido na tabela pedido. Não foi executado o 'INSERT INTO pedido'");
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         MessageBox.Show("Erro: " + e.Message);
        //     }
        //     finally
        //     {
        //         CloseConexao();
        //     }
        // }




/////////////


















        // public static void Update(
        //     int index,
        //     string idCliente,
        //     string idFuncionario,
        //     string data,
        //     string total
        // ){
        //     InitConexao();
        //     string query = "UPDATE pedido SET idCliente = @IdCliente, idFuncionario = @IdFuncionario, data = @Data, total = @Total WHERE idPedido = @Id";
        //     MySqlCommand command = new MySqlCommand(query, conexao);
        //     Pedido pedido = pedidos[index];

        //     try {
        //          if(idCliente == null || idFuncionario == null || data == null || total == null) {
        //             MessageBox.Show("Não foi possível atualizar os dados, favor preencher os campos corretamente e tentar outra vez");
        //         } else {
        //             command.Parameters.AddWithValue("@Id", funcionario.IdPedido);
        //             command.Parameters.AddWithValue("@IdCliente", idCliente);
        //             command.Parameters.AddWithValue("@IdFuncionario", idFuncionario);
        //             command.Parameters.AddWithValue("@Data", data);
        //             command.Parameters.AddWithValue("@Total", total);
        //             int rowsAffected = command.ExecuteNonQuery();
                
        //             if (rowsAffected > 0) {
        //                 pedidos[index].IdCliente = idCliente;
        //                 pedidos[index].IdFuncionario = idFuncionario;
        //                 pedidos[index].Data = data;
        //                 pedidos[index].Total = total;
        //             }
        //             else {
        //                 MessageBox.Show(rowsAffected.ToString());
        //             }
        //         }
        //     }catch (Exception ex){
        //         MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
        //     }
        //     CloseConexao();
        // }

        // public static void Delete(int index) {
        //     // MessageBox.Show("Oi desde o delete do repo");
        //     InitConexao();
        //     string delete = "DELETE FROM funcionario WHERE idPedido = @IdPedido";
        //     MySqlCommand command = new MySqlCommand(delete, conexao);

        //     try
        //     {
        //         command.Parameters.AddWithValue("@IdPedido", GetPedido(index).IdPedido);
        //         int rowsAffected = command.ExecuteNonQuery();
        //         if(rowsAffected > 0) {
        //             pedidos.RemoveAt(index);
        //             MessageBox.Show("Pedido deletado com sucesso.");
        //         } else {
        //             MessageBox.Show("Pedido não encontrado.");
        //         }
        //         CloseConexao();
        //     }
        //     catch (Exception)
        //     {
                
        //         MessageBox.Show("Para deletar um funcionário você deve selecionar o registro completo");
        //     }
        // }

    }

}






/*

using Model;
using MySqlConnector;

namespace Repo {
    public clroListPedido {
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