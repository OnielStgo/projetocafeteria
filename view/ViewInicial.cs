namespace View;
using System.Drawing;

public class ViewInicial : Form {
    private readonly Label LblTitulo;
    private readonly Label LblSubtitulo;
   
    private readonly Button BtnNovoPedido;
    private readonly Button BtnCliente;
    private readonly Button BtnProduto;
    private readonly Button BtnFuncionario;
    private readonly Button BtnHistPedido;


    public ViewInicial() {
        Size = new Size(600, 600);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Brown;

        LblTitulo = new Label {

            Text = "Cafeteria NomeCafeteria",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 10),
        };
        LblSubtitulo = new Label {
            Text = "Sistema de controle de pedidos",
            Size = new Size(450, 24),
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(80, 100),
        };
      

        BtnNovoPedido = new Button {
            Text = "Novo Pedido",
            Location = new Point(210, 200),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(180, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        // BtnNovoPedido.Click += ClickNovoPedido;

        BtnCliente = new Button {
            Text = "Clientes",
            Location = new Point(50, 300),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnCliente.Click += ClickTelaCliente;

        BtnProduto = new Button {
            Text = "Produto",
            Location = new Point(220, 300),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnProduto.Click += ClickTelaProduto;

        BtnFuncionario = new Button {
            Text = "Funcionário",
            Location = new Point(390, 300),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnFuncionario.Click += ClickTelaFuncionario;

        BtnHistPedido = new Button {
            Text = "Histórico de pedidos",
            Location = new Point(210, 380),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(250, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnHistPedido.Click += ClickHistPedido;

        Controls.Add(LblTitulo);
        Controls.Add(LblSubtitulo);
        Controls.Add(BtnNovoPedido);
        Controls.Add(BtnCliente);
        Controls.Add(BtnProduto);
        Controls.Add(BtnFuncionario);
        Controls.Add(BtnHistPedido);

        // Centralizando o Label inicialmente
        CenterControls();

        // Evento para manter o Label centralizado ao redimensionar o formulário
        this.SizeChanged += new EventHandler(ViewInicial_SizeChanged);
    }

     private void CenterControls()
    {
        LblTitulo.Left = (this.ClientSize.Width - LblTitulo.Width) / 2;
        LblTitulo.Top = this.ClientSize.Height / 8;

        LblSubtitulo.Left = (this.ClientSize.Width - LblSubtitulo.Width) / 2;
        LblSubtitulo.Top = LblTitulo.Top + LblTitulo.Height + 40;

        BtnNovoPedido.Left = (this.ClientSize.Width - BtnNovoPedido.Width) / 2;
        BtnNovoPedido.Top = LblSubtitulo.Top + LblSubtitulo.Height + 80;

        BtnCliente.Left = (this.ClientSize.Width - (BtnCliente.Width + BtnProduto.Width + BtnFuncionario.Width + 40)) / 2;
        BtnCliente.Top = BtnNovoPedido.Top + BtnNovoPedido.Height + 40;

        BtnProduto.Left = BtnCliente.Left + BtnCliente.Width + 20;
        BtnProduto.Top = BtnCliente.Top;

        BtnFuncionario.Left = BtnProduto.Left + BtnProduto.Width + 20;
        BtnFuncionario.Top = BtnCliente.Top;

        BtnHistPedido.Left = (this.ClientSize.Width - BtnHistPedido.Width) / 2;
        BtnHistPedido.Top = BtnFuncionario.Top + BtnFuncionario.Height + 80;
    }

    private void ViewInicial_SizeChanged(object sender, EventArgs e)
    {
        CenterControls();
    }

    private void ClickTelaProduto(object sender, EventArgs e)
    {
            ViewProduto viewProduto = new ViewProduto(this);
            viewProduto.FormClosed += new  FormClosedEventHandler(ViewProduto_FormClosed);
            viewProduto.Show();
            this.Hide();
    }
    private void ViewProduto_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }
    private void ClickTelaCliente(object sender, EventArgs e)
    {
            ViewCliente viewCliente = new ViewCliente(this);
            viewCliente.FormClosed += new  FormClosedEventHandler(ViewCliente_FormClosed);
            viewCliente.Show();
            this.Hide();
    }
    private void ViewCliente_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }
    private void ClickTelaFuncionario(object sender, EventArgs e)
    {
            ViewFuncionario viewFuncionario = new ViewFuncionario(this);
            viewFuncionario.FormClosed += new  FormClosedEventHandler(ViewFuncionario_FormClosed);
            viewFuncionario.Show();
            this.Hide();
    }
    private void ViewFuncionario_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }

    private void ClickHistPedido(object sender, EventArgs e)
    {
            ViewPedido viewPedido = new ViewPedido(this);
            viewPedido.FormClosed += new  FormClosedEventHandler(ViewPedido_FormClosed);
            viewPedido.Show();
            this.Hide();
    }
    private void ViewPedido_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }
}



/*


using Controller;
using Model;

namespace View;

public class ViewPessoa : Form {

    private readonly Label LblTitulo;
    private readonly Label LblData;
    private readonly Label LblHora;
    private readonly Label LblConcluida;
    private readonly TextBox InpTitulo;
    private readonly TextBox InpData;
    private readonly TextBox InpHora;
    private readonly TextBox InpConcluida;
    private readonly Button BtnCadastrar;
    private readonly Button BtnAlterar;
    private readonly Button BtnDeletar;
    private readonly DataGridView DgvPessoas;

    public ViewPessoa() {
        ControllerPessoa.Sincronizar();
        Size = new Size(600, 600);
        StartPosition = FormStartPosition.CenterScreen;

        LblTitulo = new Label {
            Text = "Titulo: ",
            Location = new Point(50, 50),
        };
        LblData = new Label {
            Text = "Data: ",
            Location = new Point(50, 100),
        };
        LblHora = new Label {
            Text = "Hora: ",
            Location = new Point(50, 150),
        };

        LblConcluida = new Label {
            Text = "Concluida: ",
            Location = new Point(50, 200),
        };

        InpTitulo = new TextBox {
            Name = "Titulo",
            Location = new Point(150, 50),
            Size = new Size(200, 20)
        };
        InpData = new TextBox {
            Name = "Data",
            Location = new Point(150, 100),
            Size = new Size(200, 20)
        };
        InpHora = new TextBox {
            Name = "Hora",
            Location = new Point(150, 150),
            Size = new Size(200, 20)
        };
        InpConcluida = new TextBox {
            Name = "Concluida",
            Location = new Point(150, 200),
            Size = new Size(200, 20)
        };

        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 250),
        };
        BtnCadastrar.Click += ClickCadastrar;
        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(150, 250),
        };
        BtnAlterar.Click += ClickAlterar;
        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(250, 250),
        };
        BtnDeletar.Click += ClickDeletar;

        DgvPessoas = new DataGridView {
            Location = new Point(0, 300),
            Size = new Size(550, 150)
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblData);
        Controls.Add(LblHora);
        Controls.Add(LblConcluida);
        Controls.Add(InpTitulo);
        Controls.Add(InpData);
        Controls.Add(InpHora);
        Controls.Add(InpConcluida);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDeletar);
        Controls.Add(DgvPessoas);
        Listar();
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpTitulo.Text == "") {
            return;
        }
        ControllerPessoa.CriarPessoa(InpTitulo.Text, InpData.Text, InpHora.Text, InpConcluida.Text);
        Listar();
    }
    
    private void ClickAlterar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        if(InpTitulo.Text == "") {
            return;
        }
        ControllerPessoa.AlterarPessoa(index, InpTitulo.Text, InpData.Text, InpHora.Text, InpConcluida.Text);
        Listar();
    }

    private void Listar() {
        List<Pessoa> pessoas = ControllerPessoa.ListarPessoa();
        DgvPessoas.Columns.Clear();
        DgvPessoas.AutoGenerateColumns = false;
        DgvPessoas.DataSource = pessoas;
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Titulo",
            HeaderText = "Titulo"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Data",
            HeaderText = "Data"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Hora",
            HeaderText = "Hora"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Concluida",
            HeaderText = "Concluida"
        });
    }
    private void ClickDeletar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        ControllerPessoa.DeletarPessoa(index);
        Listar();
    }


}



*/