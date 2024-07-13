using Model;
using MySqlConnector;

namespace Repo {
    public class ListPedidoProduto {
        static public List<PedidoProduto> pedidoprodutos = new List<PedidoProduto>();
        static private MySqlConnection conexao;
        public static void InitConexao() {
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

        public static List<PedidoProduto> ObterDetalhesDeUmPedido(int idPedido) {
            pedidoprodutos.Clear();
            InitConexao();
            if (conexao.State == System.Data.ConnectionState.Open) {
                string query = "SELECT * FROM pedido_produto WHERE idPedido=@IdPedido";
                MySqlCommand command = new MySqlCommand(query, conexao);
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