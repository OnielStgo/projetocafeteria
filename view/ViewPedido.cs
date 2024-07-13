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

    private int idPed_Prod { set; get; }

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
        // DgvPedido.CellClick += MostrarDetalheDoPedido;
        DgvPedido.CellClick += ClickDetalhesDePedido;

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
            DataPropertyName = "IdPedido",
            HeaderText = "Id_Pedido",
            Width = 70
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdCliente",
            HeaderText = "Id_Cliente",
            Width = 70
        });

        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdFuncionario",
            HeaderText = "Id_Funcionario",
            Width = 100
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "data",
            HeaderText = "Data",
            Width = 110,
        });
        DgvPedido.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "total",
            HeaderText = "Total",
            Width = 60,
        });
    }

    // private void MostrarDetalheDoPedido(object sender, DataGridViewCellEventArgs e) {
    //     // Verifica se o índice da linha é válido
    //     if (e.RowIndex >= 0)
    //     {
    //         // Acessa a linha clicada
    //         DataGridViewRow row = DgvPedido.Rows[e.RowIndex];

    //         // Chama a função e passa a linha clicada
    //         ExecuteFunction(row);
    //     }        
    // }

    // private void ExecuteFunction(DataGridViewRow row)
    // {
    //     // Exemplo: Acessa o valor da primeira célula da linha
    //     var cellValue = row.Cells[0].Value;
    //     idPed_Prod = Convert.ToInt32(cellValue);

    //     MessageBox.Show($"Valor da célula: {cellValue}");
                
    // }


    private void ClickDetalhesDePedido(object sender, DataGridViewCellEventArgs e)
    {

        int numero = 0;

        if (e.RowIndex >= 0)
        {
            // Acessa a linha clicada
            DataGridViewRow row = DgvPedido.Rows[e.RowIndex];

            var cellValue = row.Cells[0].Value;
            numero = Convert.ToInt32(cellValue);

            // MessageBox.Show($"Valor da célula: {cellValue}");   
        }  
            



            // ViewProdutosDoPedido viewProdutosDoPedido = new ViewProdutosDoPedido(this);
            ViewProdutosDoPedido viewProdutosDoPedido = new ViewProdutosDoPedido(this, numero);
            viewProdutosDoPedido.FormClosed += new FormClosedEventHandler(ViewProdutosDoPedido_FormClosed);
            viewProdutosDoPedido.Show();
            this.Hide();
    }
    private void ViewProdutosDoPedido_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }
















    // private void MostrarDetalheDoPedido(object sender, DataGridViewCellEventArgs e) {
    //     // Verifica se o índice da linha é válido
    //     if (e.RowIndex >= 0)
    //     {
    //         // Acessa a linha clicada
    //         DataGridViewRow row = DgvPedido.Rows[e.RowIndex];

    //         // Chama a função e passa a linha clicada
    //         ExecuteFunction(row);
    //     }        
    // }

    // private void ExecuteFunction(DataGridViewRow row)
    // {
    //     // Exemplo: Acessa o valor da primeira célula da linha
    //     var cellValue = row.Cells[0].Value;
    //     idPed_Prod = Convert.ToInt32(cellValue);

    //     MessageBox.Show($"Valor da célula: {cellValue}");
                
    // }
    
    // private void ClickDetalhesDePedido(object sender, EventArgs e)
    // {
    //         ViewNovoPedido viewNovoPedido = new ViewNovoPedido(this);
    //         viewNovoPedido.FormClosed += new  FormClosedEventHandler(ViewNovoPedido_copy);
    //         viewNovoPedido.Show();
    //         this.Hide();
    // }
    // private void ViewNovoPedido_copy(object sender, EventArgs e)
    // {
    //     this.Show();
    // }
}