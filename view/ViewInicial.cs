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
        BtnNovoPedido.Click += ClickNovoPedido;

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
            Text = "Produtos",
            Location = new Point(220, 300),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnProduto.Click += ClickTelaProduto;

        BtnFuncionario = new Button {
            Text = "Funcionários",
            Location = new Point(390, 300),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(160, 30),
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

        CentralizarElementos();

        // Evento para manter os componentes centralizados ao redimensionar o formulário
        this.SizeChanged += new EventHandler(ViewInicial_SizeChanged);
    }

     private void CentralizarElementos()
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
        CentralizarElementos();
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
    private void ClickNovoPedido(object sender, EventArgs e)
    {
            ViewNovoPedido viewNovoPedido = new ViewNovoPedido(this);
            viewNovoPedido.FormClosed += new  FormClosedEventHandler(ViewNovoPedido_FormClosed);
            viewNovoPedido.Show();
            this.Hide();
    }
    private void ViewNovoPedido_FormClosed(object sender, EventArgs e)
    {
        this.Show();
    }
}