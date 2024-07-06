namespace View;
using System.Drawing;
using Controller;
using Model;

public class ViewProduto : Form {

    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Label LblTotalProdutos;
    private readonly Label LblTotalProdutosNumber;
    private readonly Label LblSubTitulo;
    private readonly Label LblCodigo;    
    private readonly TextBox InpCodigo;
    private readonly Label LblDescricao;    
    private readonly TextBox InpDescricao;
    private readonly Label LblPreco;    
    private readonly TextBox InpPreco;

    private readonly Button BtnCadastrar;
    private readonly Button BtnAlterar;
    private readonly Button BtnDeletar;

    private readonly DataGridView DgvProdutos;

    public ViewProduto(Form parent) {
        ControllerProduto.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Blue;

        LblTitulo = new Label {

            Text = "PRODUTOS",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 10),
        };
        LblTotalProdutos = new Label {
            Text = "Número total de produtos:",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 100),
        };
        LblTotalProdutosNumber = new Label {
            Text = "Número",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(330, 100),
        };
        LblSubTitulo = new Label {
            Text = "A seguir campos para cadastrar ou alterar um produto",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 150),
        };
        LblCodigo = new Label {
            Text = "Código",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 200),
        };
        InpCodigo = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 200),
        };
        LblDescricao = new Label {
            Text = "Descrição",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 250),
        };
        InpDescricao = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 250),
        };
        LblPreco = new Label {
            Text = "Preço",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 300),
        };
        InpPreco = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 300),
        };


        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnCadastrar.Click += ClickCadastrar;

        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(220, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnAlterar.Click += ClickAlterar;

        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(390, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnDeletar.Click += ClickDeletar;
       
        DgvProdutos = new DataGridView {
            Location = new Point(30, 450),
            Size = new Size(550, 250),
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblTotalProdutos);
        Controls.Add(LblTotalProdutosNumber);
        Controls.Add(LblSubTitulo);
        Controls.Add(LblCodigo);
        Controls.Add(InpCodigo);
        Controls.Add(LblDescricao);
        Controls.Add(InpDescricao);
        Controls.Add(LblPreco);
        Controls.Add(InpPreco);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDeletar);
        Controls.Add(DgvProdutos);
        Listar();
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpCodigo.Text == "") {
            return;
        }
        ControllerProduto.CriarProduto(InpCodigo.Text, InpDescricao.Text, Convert.ToDecimal(InpPreco.Text));
        Listar();
        InpCodigo.Text = "";
        InpDescricao.Text = "";
        InpPreco.Text = "";
    }
    
    private void ClickAlterar(object? sender, EventArgs e) {
        try
        {
            int index = DgvProdutos.SelectedRows[0].Index;
            if(InpCodigo.Text == "") {
                return;
            }
            ControllerProduto.AlterarProduto(index, InpCodigo.Text, InpDescricao.Text, Convert.ToDecimal(InpPreco.Text));
            Listar();
        }
        catch (Exception)
        {            
            MessageBox.Show("Para alterar um produto, você deve preencher todos os campos corretamente");
        }
    }

    private void Listar() {
        List<Produto> produtos = ControllerProduto.ListarProduto();
        DgvProdutos.Columns.Clear();
        DgvProdutos.AutoGenerateColumns = false;
        DgvProdutos.DataSource = produtos;

        // DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
        //     DataPropertyName = "IdProduto",
        //     HeaderText = "Id",
        //     Width = 50
        // });

        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "codigo",
            HeaderText = "Código"
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "descricao",
            HeaderText = "Descrição",
            Width = 300
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "preco",
            HeaderText = "Preço"
        });
    }
    private void ClickDeletar(object? sender, EventArgs e) {
        try
        {
            int index = DgvProdutos.SelectedRows[0].Index;
            ControllerProduto.DeletarProduto(index);
            Listar();
        }
        catch (Exception)
        {
            MessageBox.Show("Para deletar um produto, você deve selecionar a fila completa");
        }
    }
}