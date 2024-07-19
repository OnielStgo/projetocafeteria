namespace View;
using System.Drawing;
using Controller;
using Model;

public class ViewNovoPedido : Form {

    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Button BtnAjuda;
    private readonly Label LblSubTitulo;
    private readonly Label LblIdCliente;    
    private readonly TextBox InpIdCliente;
    private readonly Label LblIdFuncionario;    
    private readonly TextBox InpIdFuncionario;
    private readonly Label LblCodProduto;    
    private readonly ComboBox CbbCodProduto;
    private List<string> listaDescricaoProdutos;
    private List<decimal> listaPrecoDeProdutos; 
    private readonly Label LblQuantidade;    
    private readonly TextBox InpQuantidade;
    private readonly Label LblSubTituloTotal;    
    private readonly Label LblTotalValor;
    private readonly Button BtnAddProduto;
    private readonly Button BtnFinalizar;
    public decimal TotalDoProduto { set; get; }
    public decimal ValorTotal { set; get; }
    public int IndiceProduto { set; get; }
    private readonly DataGridView DgvProdutos;
    private readonly string CorFundo = "#CD853F";
    private readonly string CorTitulos = "#8B4513";
    private readonly string CorCamposParaPrencher = "#F4A460";
    private readonly string CorBotao = "#A0522D";

    public ViewNovoPedido(Form parent) {
        ControllerProduto.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = ColorTranslator.FromHtml(CorFundo);

        LblTitulo = new Label {
            Text = "NOVO PEDIDO",
            Size = new Size(420, 35),
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

        LblSubTitulo = new Label {
            Text = "A seguir campos para adicionar um novo pedido",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(CorTitulos),
            Location = new Point(60, 100),
        };
        LblIdCliente = new Label {
            Text = "IdCliente",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(160, 170),
        };
        InpIdCliente = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 170),
        };
        LblIdFuncionario = new Label {
            Text = "IdFuncionário",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(160, 220),
        };
        InpIdFuncionario = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 220),
        };
        LblCodProduto = new Label {
            Text = "Produto",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(100, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(180, 270),
        };
        CbbCodProduto = new ComboBox
        {
            Location = new Point(300, 270),
            Width = 250,
            AutoCompleteMode = AutoCompleteMode.SuggestAppend,
            AutoCompleteSource = AutoCompleteSource.CustomSource,
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
        };
        LblQuantidade = new Label {
            Text = "Quantidade",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(160, 320),
        };
        InpQuantidade = new TextBox {
            Size = new Size(100, 80),
            BackColor = ColorTranslator.FromHtml(CorCamposParaPrencher),
            Location = new Point(300, 320),
        };
        LblSubTituloTotal = new Label {
            Text = "Valor total do pedido:  R$",
            Size = new Size(225, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            Location = new Point(250, 680),
        };
        LblTotalValor = new Label {
            Text = "",
            Font = new Font("Arial", 14, FontStyle.Bold),
            Size = new Size(100, 24),
            Location = new Point(480, 680),
        };
        BtnAddProduto = new Button {
            Text = "Adicionar Pod.",
            Location = new Point(420, 360),
            Font = new Font("Arial", 14, FontStyle.Bold),
            Size = new Size(160, 25),
            BackColor = ColorTranslator.FromHtml(CorBotao),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnAddProduto.Click += ClickAddProduto;

         BtnFinalizar = new Button {
            Text = "Finalizar",
            Location = new Point(430, 720),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = ColorTranslator.FromHtml(CorBotao),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnFinalizar.Click += ClickFinalizar;
     
        DgvProdutos = new DataGridView {
            Location = new Point(30, 410),
            Size = new Size(550, 250),
        };
        DgvProdutos.ColumnCount = 4;
        DgvProdutos.Columns[0].Name = "Qtde";
        DgvProdutos.Columns[0].Width = 60;
        DgvProdutos.Columns[1].Name = "Descrição";
        DgvProdutos.Columns[1].Width = 290;
        DgvProdutos.Columns[2].Name = "Preço";
        DgvProdutos.Columns[2].Width = 70;
        DgvProdutos.Columns[3].Name = "Total";
        DgvProdutos.Columns[3].Width = 90;

        Controls.Add(LblTitulo);
        Controls.Add(BtnAjuda);
        Controls.Add(LblSubTitulo);
        Controls.Add(LblIdCliente);
        Controls.Add(InpIdCliente);
        Controls.Add(LblIdFuncionario);
        Controls.Add(InpIdFuncionario);
        Controls.Add(LblCodProduto);
        Controls.Add(CbbCodProduto);
        Controls.Add(LblQuantidade);
        Controls.Add(InpQuantidade);
        Controls.Add(LblSubTituloTotal);
        Controls.Add(LblTotalValor);
        Controls.Add(BtnAddProduto);
        Controls.Add(BtnFinalizar);
        Controls.Add(DgvProdutos);

        CarregarProdutosNoComboBox();
        ConfigurarAutoCompleteDoComboBox();
    }

    private void CarregarProdutosNoComboBox()
    {
        CbbCodProduto.Items.Clear();
        List<Produto> produtos = ControllerProduto.Sincronizar();
        listaDescricaoProdutos = produtos.Select(p => p.Descricao).ToList();
        foreach (var descricao in listaDescricaoProdutos)
        {
            CbbCodProduto.Items.Add(descricao);
        }
    }

    private void ConfigurarAutoCompleteDoComboBox()
    {
        var autoCompleteCollection = new AutoCompleteStringCollection();
        autoCompleteCollection.AddRange(listaDescricaoProdutos.ToArray());
        CbbCodProduto.AutoCompleteCustomSource = autoCompleteCollection;
    }

    private void ClickAjuda(object? sender, EventArgs e) {
        MessageBox.Show("AJUDA:\n\n- Para realiar um novo pedido primerio peencha os campos 'IdCliente', 'IdFuncionário', 'Produto' e 'Quantidade' e depois clique no botão 'Adicionar Prod.'. Repita este procedimento até adicionar todos os produtos do pedido e por último clique no botão 'Finalizar' para salvar o pedido");
    }

    private void ClickAddProduto(object? sender, EventArgs e) {
        try
        {
            if(InpIdCliente.Text == "" || InpIdFuncionario.Text == "" || CbbCodProduto.Text == "" || InpQuantidade.Text == "") {
                MessageBox.Show("Favor verificar os campos e tentar outra vez");
                return;
            }
     
            if (!(int.TryParse(InpIdCliente.Text, out int result) && int.TryParse(InpIdFuncionario.Text, out int result2) && int.TryParse(InpQuantidade.Text, out int result3)))
            {
                MessageBox.Show("Não foi possível adicionar o produto, favor revisar os campos e tentar outra vez.");
                return;
            }
    
            string idcliente = InpIdCliente.Text;
            string idfuncionario = InpIdFuncionario.Text;
            string descricao = CbbCodProduto.Text;

            List<Produto> produtos = ControllerProduto.Sincronizar();
            int indiceDoProduto = 0;
            int idDoProduto = 0;

            foreach (var descricaoProduto in listaDescricaoProdutos)
            {
                if (descricao == descricaoProduto)
                {
                    indiceDoProduto = listaDescricaoProdutos.IndexOf(descricaoProduto);
                    idDoProduto = produtos[indiceDoProduto].IdProduto;
                }
            }

            if (idDoProduto == 0)
            {
                MessageBox.Show("O nome do produto está incorrreto, favor selecione o produto correto e tente outra vez");
                return;
            }

            int IndiceProdutoSelecionado = CbbCodProduto.SelectedIndex + 1;
            string qtdeEmtring = InpQuantidade.Text;
            int qtde = Convert.ToInt32(InpQuantidade.Text);
            List<decimal> listaPrecoDeProdutos = produtos.Select(p => p.Preco).ToList();
            decimal preco = listaPrecoDeProdutos[IndiceProdutoSelecionado];
            decimal totalDoProduto = Convert.ToDecimal(qtdeEmtring) * preco;

            ControllerProdutosDoPedido.CriarProdutosDoPedido(idDoProduto, qtde, totalDoProduto);
            Listar(qtdeEmtring, descricao, idDoProduto);

            CbbCodProduto.Text = "";
            InpQuantidade.Text = "";
            return;
        }
        catch (Exception ex)
        {            
            MessageBox.Show("Não foi possível adicionar o produto no pedido" + ex);
        }
    }

    private void Listar(string qtde, string descricao, int IndiceProduto) {

        List<Produto> produtos = ControllerProduto.Sincronizar();
        listaPrecoDeProdutos = produtos.Select(p => p.Preco).ToList();

        string precoEmString = Convert.ToString(listaPrecoDeProdutos[IndiceProduto]);
        decimal preco = listaPrecoDeProdutos[IndiceProduto];
        TotalDoProduto = Convert.ToDecimal(qtde) * preco;
        ValorTotal += TotalDoProduto;
        LblTotalValor.Text = Convert.ToString(ValorTotal);
        string totalEmString = Convert.ToString(TotalDoProduto);

        string[] row = new string[] { qtde, descricao, precoEmString, totalEmString };
        DgvProdutos.Rows.Add(row);
    }

    private void ClickFinalizar(object? sender, EventArgs e) {

        if(LblTotalValor.Text == "") {
            MessageBox.Show("Não há nenhum pedido para salvar");
            return;
        }
        int idcliente = Convert.ToInt32(InpIdCliente.Text);
        int idfuncionario = Convert.ToInt32(InpIdFuncionario.Text);

        List<ProdutosDoPedido> produtosDoPedido = ControllerProdutosDoPedido.ObterProdutosDoPedido();        
        ControllerPedido.CriarPedido(idcliente, idfuncionario, ValorTotal, produtosDoPedido);

        ValorTotal = 0;
        produtosDoPedido.Clear();
        DgvProdutos.Rows.Clear();

        InpIdCliente.Text = "";
        InpIdFuncionario.Text = "";
        InpQuantidade.Text = "";
        LblTotalValor.Text = "";
    }
}