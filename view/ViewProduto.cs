namespace View;
using System.Drawing;
using Controller;
using Model;

public class ViewProduto : Form {

    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Button BtnAjuda;
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
    private readonly string CorFundo = "#CD853F";
    private readonly string CorTitulos = "#8B4513";
    private readonly string CorCamposParaPrencher = "#F4A460";
    private readonly string CorBotao = "#A0522D";
    public ViewProduto(Form parent) {
        ControllerProduto.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = ColorTranslator.FromHtml(CorFundo);

        LblTitulo = new Label {
            Text = "PRODUTOS",
            Size = new Size(400, 40),
            Font = new Font("Arial", 32, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(120, 30),
        };
        BtnAjuda = new Button {
            Text = "Ajuda",
            Size = new Size(60, 30),
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(540, 20),
        };
        BtnAjuda.Click += ClickAjuda;

        LblTotalProdutos = new Label {
            Text = "Número total de produtos cadastrados:",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(85, 100),
        };
        LblTotalProdutosNumber = new Label {
            Text = "",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(500, 100),
        };
        LblSubTitulo = new Label {
            Text = "A seguir campos para cadastrar ou alterar um produto",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(30, 150),
        };
        LblCodigo = new Label {
            Text = "Código",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(195, 200),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        InpCodigo = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 200),
        };
        LblDescricao = new Label {
            Text = "Descrição",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(195, 250),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        InpDescricao = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 250),
        };
        LblPreco = new Label {
            Text = "Preço",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(195, 300),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        InpPreco = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 300),
        };

        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = ColorTranslator.FromHtml(CorBotao),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnCadastrar.Click += ClickCadastrar;

        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(220, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = ColorTranslator.FromHtml(CorBotao),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnAlterar.Click += ClickAlterar;

        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(390, 400),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = ColorTranslator.FromHtml(CorBotao),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnDeletar.Click += ClickDeletar;
       
        DgvProdutos = new DataGridView {
            Location = new Point(30, 450),
            Size = new Size(550, 250),
        };

        Controls.Add(LblTitulo);
        Controls.Add(BtnAjuda);
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

    private void ClickAjuda(object? sender, EventArgs e) {
        MessageBox.Show("AJUDA:\n\n- Para cadastrar um novo produto primerio peencha todos os campos e depois clique no botão 'Cadastrar'.\n\n- Para alterar os dados de um produto cadastrado, primerio selecione o produto clicando na coluna vazia da extrema esquerda para selecionar a fila enteira, depois preencha os campos e por útlimo clique no botão 'Alterar'.\n\n- Para deletar um produto cadastrado, primerio selecione o produto clicando na coluna vazia da extrema esquerda para selecionar a fila enteira, e depois clique no botão 'Deletar'. ");
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
        LblTotalProdutosNumber.Text = Convert.ToString(produtos.Count);
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