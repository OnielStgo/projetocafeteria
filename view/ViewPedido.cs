namespace View;
using System.Drawing;
using Controller;
using Model;
public class ViewPedido : Form {
    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Label LblTotalPedido;
    private readonly Label LblTotalPedidoNumber;
    private readonly DataGridView DgvPedido;

    public ViewPedido(Form parent) {
        ControllerPedido.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Blue;

        LblTitulo = new Label {

            Text = "HISTÓRICO DE PEDIDOS",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 20),
        };
        LblTotalPedido = new Label {
            Text = "Número total de pedidos realizados:",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 100),
        };
        LblTotalPedidoNumber = new Label {
            Text = "Número",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(450, 100),
        };
       
        DgvPedido = new DataGridView {
            Location = new Point(110, 200),
            Size = new Size(400, 500),
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblTotalPedido);
        Controls.Add(LblTotalPedidoNumber);
        Controls.Add(DgvPedido);
        Listar();
    }
    private void Listar() {
        List<Pedido> pedidos = ControllerPedido.ListarPedido();
        DgvPedido.Columns.Clear();
        DgvPedido.AutoGenerateColumns = false;
        DgvPedido.DataSource = pedidos;

        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdCliente",
            HeaderText = "Cliente",
            Width = 80
        });

        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdFuncionario",
            HeaderText = "Funcionario",
            Width = 80
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "data",
            HeaderText = "Data",
            Width = 100,
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "total",
            HeaderText = "Total",
            Width = 80,
        });
    }
}