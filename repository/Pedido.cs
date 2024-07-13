using Model;
using MySqlConnector;

namespace Repo {
    public class ListPedido {
        static public List<Pedido> pedidos = new List<Pedido>();
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
        public static Pedido? GetPedido(int index){
            if(index < 0 || index >= pedidos.Count){
                return null;
            }else {
                return pedidos[index];
            }
        }

        public static List<Pedido> Sincronizar() {
            pedidos.Clear();
            InitConexao();

            string query = "SELECT * FROM pedido";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Pedido pedido = new Pedido();
                pedido.IdPedido = Convert.ToInt32(reader["idPedido"].ToString());
                pedido.IdCliente = Convert.ToInt32(reader["idCliente"].ToString());
                pedido.IdFuncionario = Convert.ToInt32(reader["idFuncionario"].ToString());
                pedido.Data = Convert.ToDateTime(reader["data"].ToString()) ;
                pedido.Total = Convert.ToDecimal(reader["total"].ToString());
                pedidos.Add(pedido);
            }

            CloseConexao();
            return pedidos;
        }
        
        public static void Criar(Pedido pedido, List<ProdutosDoPedido> produtosDoPedido) {

            InitConexao();

            string insert = "INSERT INTO pedido (idCliente, idFuncionario, data, total) VALUES (@IdCliente, @IdFuncionario, @Data, @Total)";
            MySqlCommand command = new MySqlCommand(insert, conexao);

            try {
                if(pedido.IdCliente < 0 || pedido.IdFuncionario < 0 || Convert.ToString(pedido.Data) == null || pedido.Total < 0) {
                    MessageBox.Show("Não foi possível adicionar o pedido, favor preencher os campos corretamente e tentar outra vez. Message desde o médoto Criar o repository Pedido");
                } else {
                    command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
                    command.Parameters.AddWithValue("@IdFuncionario", pedido.IdFuncionario);
                    command.Parameters.AddWithValue("@Data", pedido.Data);
                    command.Parameters.AddWithValue("@Total", pedido.Total);

                    int rowsAffected = command.ExecuteNonQuery();                    
                    int ultimoId = Convert.ToInt32(command.LastInsertedId);
                    // int LastIdPedidoInserido = Convert.ToInt32(command.LastInsertedId);
                    string idPedidoAsString = Convert.ToString(ultimoId);
                    MessageBox.Show("O id do pedido insertado é: " + idPedidoAsString + " Messagem desde o método Criar do repo ListPedido");

                    if(rowsAffected > 0){
                        // pedidos.Add(pedido);
                        MessageBox.Show("Pedido salvo na tabela 'pedido'. Foi executado o 'INSERT INTO pedido' corretamente");

                        string insert2 = "INSERT INTO pedido_produto (idPedido, idProduto, quantidade, total) VALUES (@IdPedido2, @IdProduto, @Quantidade, @TotalDoProduto)";                        
                        MySqlCommand command2 = new MySqlCommand(insert2, conexao);

                        foreach (var item in produtosDoPedido)
                        {
                            if(ultimoId < 0 || item.IdProduto < 0 || item.QuantidadePorProduto < 0 || item.TotalPorProduto < 0) {
                            MessageBox.Show("Não foi possível adicionar o pedidoproduto, favor preencher os campos corretamente e tentar outra vez");
                            } else {
                                command2.Parameters.Clear();
                                command2.Parameters.AddWithValue("@IdPedido2", ultimoId);
                                command2.Parameters.AddWithValue("@IdProduto", item.IdProduto);
                                command2.Parameters.AddWithValue("@Quantidade", item.QuantidadePorProduto);
                                command2.Parameters.AddWithValue("@TotalDoProduto", item.TotalPorProduto);

                                int rowsAffected2 = command2.ExecuteNonQuery();
                                if(rowsAffected2 > 0){
                                    MessageBox.Show("Registro salvo na tabela 'pedidoproduto'. Foi executado o 'INSERT INTO pedidoproduto' corretamente");
                                    // pedidoprodutos.Add(pedidoproduto);
                                } else {
                                    MessageBox.Show("Não foi possível executar o 'INSERT INTO pedidoproduto'");
                                }
                            }
                        }

                    } else {
                        MessageBox.Show("Não foi possível adicionar o pedido na tabela pedido. Não foi executado o 'INSERT INTO pedido'");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("message desde o catch do método Criar o repo");
                MessageBox.Show("Deu ruim: " + e.Message + " Messagem desde o catch do try/catch que esta´dentro do método Criar no repository Pedido");
            }
            CloseConexao();
        }

    }

}