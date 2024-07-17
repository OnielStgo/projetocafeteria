namespace View;
using System.Drawing;
using Controller;
using Model;
public class ViewProdutosDoPedido : Form {
    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Label LblTotalPedido;
    private readonly Label LblTotalPedidoNumber;
    private readonly DataGridView DgvPedido;
    private readonly string CorFundo = "#CD853F";
    private readonly string CorTitulos = "#8B4513";

    public ViewProdutosDoPedido(Form parent, int idDoPedido) {
        ControllerPedido.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = ColorTranslator.FromHtml(CorFundo);

        LblTitulo = new Label {
            Text = "DETALHES DO PEDIDO",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 20),
        };
        LblTotalPedido = new Label {
            Text = "Número total de produtos no pedido:",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(100, 100),
        };
        LblTotalPedidoNumber = new Label {
            Text = "",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(490, 100),
        };       
        DgvPedido = new DataGridView {
            Location = new Point(110, 200),
            Size = new Size(400, 500),
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblTotalPedido);
        Controls.Add(LblTotalPedidoNumber);
        Controls.Add(DgvPedido);
        Listar(idDoPedido);
    }
    private void Listar(int idDoPedido) {
        List<PedidoProduto> pedidoprodutos = ControllerPedidoProduto.ObterDetalhesDeUmPedido(idDoPedido);
        LblTotalPedidoNumber.Text = Convert.ToString(pedidoprodutos.Count);
        DgvPedido.Columns.Clear();
        DgvPedido.AutoGenerateColumns = false;
        DgvPedido.DataSource = pedidoprodutos;
      
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdPedido",
            HeaderText = "Id_Pedido",
            Width = 70
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdProduto",
            HeaderText = "Id_Produto",
            Width = 100
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Quantidade",
            HeaderText = "Id_Quantidade",
            Width = 110,
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "total",
            HeaderText = "Total",
            Width = 60,
        });
    }
}