namespace View;
using System.Drawing;
using System.Security.AccessControl;
// using System.Collections.Generic;
// using System;
using Controller;
using Model;
using Repo;

public class ViewNovoPedido : Form {

    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    // private readonly Label LblSubTituloTotalProdutos;
    // private readonly Label LblSubTituloTotalProdutosNumber;
    private readonly Label LblSubTitulo;
    private readonly Label LblIdCliente;    
    private readonly TextBox InpIdCliente;
    private readonly Label LblIdFuncionario;    
    private readonly TextBox InpIdFuncionario;
    private readonly Label LblCodProduto;    
    // private readonly TextBox InpCodProduto;
    private readonly ComboBox CbbCodProduto;
    private List<string> listaDescricaoProdutos;
    private List<string> listaCodigoDeProdutos; 
    private List<decimal> listaPrecoDeProdutos; 
    private List<decimal> listaPrecoDeProdutos2; 
    private readonly Label LblQuantidade;    
    private readonly TextBox InpQuantidade;
    private readonly TextBox InpTeste;
    private readonly Label LblSubTituloTotal;    
    private readonly Label LblTotalValor;

    private readonly Button BtnAddProduto;
    private readonly Button BtnFinalizar;
    // private readonly Button BtnDeletar;

    public decimal TotalDoProduto { set; get; }
    public decimal ValorTotal { set; get; }
    public int IndiceProduto { set; get; }
    public int idDoProduto2 { set; get; }

    private readonly DataGridView DgvProdutos;

    public ViewNovoPedido(Form parent) {
        ControllerProduto.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Blue;

        LblTitulo = new Label {

            Text = "NOVO PEDIDO",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 20),
        };
        LblSubTitulo = new Label {
            Text = "A seguir campos para adicionar um novo pedido",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 100),
        };
        LblIdCliente = new Label {
            Text = "IdCliente",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(160, 170),
        };
        InpIdCliente = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 170),
        };
        LblIdFuncionario = new Label {
            Text = "IdFuncionário",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(160, 220),
        };
        InpIdFuncionario = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 220),
        };
        LblCodProduto = new Label {
            Text = "Produto",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(90, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(200, 270),
        };
        // InpCodProduto = new TextBox {
        //     Size = new Size(100, 80),
        //     BackColor = Color.Aqua,
        //     Location = new Point(300, 270),
        // };

        CbbCodProduto = new ComboBox
        {
            Location = new Point(300, 270),
            Width = 250,
            AutoCompleteMode = AutoCompleteMode.SuggestAppend,
            AutoCompleteSource = AutoCompleteSource.CustomSource,   
        };

        LblQuantidade = new Label {
            Text = "Quantidade",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(130, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(160, 320),
        };
        InpQuantidade = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 320),
        };
        // InpQuantidade.Text = "7";

        InpTeste = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 340),
        };
        LblSubTituloTotal = new Label {
            Text = "Valor total do pedido:  R$",
            Size = new Size(225, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(250, 680),
        };
        LblTotalValor = new Label {
            Text = "",
            Font = new Font("Arial", 14, FontStyle.Bold),
            Size = new Size(100, 24),
            BackColor = Color.Aqua,
            Location = new Point(480, 680),
        };

       BtnAddProduto = new Button {
            Text = "Adicionar Pod.",
            Location = new Point(420, 360),
            Font = new Font("Arial", 14, FontStyle.Bold),
            Size = new Size(160, 25),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnAddProduto.Click += ClickAddProduto;

         BtnFinalizar = new Button {
            Text = "Finalizar",
            Location = new Point(430, 720),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
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
        Controls.Add(LblSubTitulo);
        Controls.Add(LblIdCliente);
        Controls.Add(InpIdCliente);
        Controls.Add(LblIdFuncionario);
        Controls.Add(InpIdFuncionario);
        Controls.Add(LblCodProduto);
        Controls.Add(CbbCodProduto);
        // Controls.Add(InpCodProduto);
        Controls.Add(LblQuantidade);
        Controls.Add(InpQuantidade);
        Controls.Add(InpTeste);
        Controls.Add(LblSubTituloTotal);
        Controls.Add(LblTotalValor);
        Controls.Add(BtnAddProduto);
        Controls.Add(BtnFinalizar);
        Controls.Add(DgvProdutos);
        // Listar();

        CarregarProdutosNoComboBox();
        ConfigurarAutoCompleteDoComboBox();
    }

    private void ClickFinalizar(object? sender, EventArgs e) {

        if(LblTotalValor.Text == "") {
            MessageBox.Show("Não há nenhum pedido para salvar");
            return;
        }
        int idcliente = Convert.ToInt32(InpIdCliente.Text);
        int idfuncionario = Convert.ToInt32(InpIdFuncionario.Text);
        // int quantidade = Convert.ToInt32(InpQuantidade.Text);
        // int quantidade = Convert.ToInt32(InpTeste.Text);

        List<ProdutosDoPedido> produtosDoPedido = ControllerProdutosDoPedido.ObterProdutosDoPedido();
        ControllerPedido.CriarPedido(idcliente, idfuncionario, ValorTotal, produtosDoPedido);
        ValorTotal = 0;
        // LblTotalValor.Text = "";
        produtosDoPedido.Clear();
        DgvProdutos.Rows.Clear();
        // Listar();

        InpIdCliente.Text = "";
        InpIdFuncionario.Text = "";
        InpQuantidade.Text = "";
        InpTeste.Text = "";
        LblTotalValor.Text = "";
    }

    private void ClickAddProduto(object? sender, EventArgs e) {
        try
        {
            // int index = DgvProdutos.SelectedRows[0].Index;

            if(InpIdCliente.Text == "" || InpIdFuncionario.Text == "" || CbbCodProduto.Text == "" || InpTeste.Text == "") {
                MessageBox.Show("Favor verificar os campos e tentar outra vez");
                return;
            }

            string idcliente = InpIdCliente.Text;
            string idfuncionario = InpIdFuncionario.Text;
            string descricao = CbbCodProduto.Text;

            List<Produto> produtos = ControllerProduto.Sincronizar();
            listaCodigoDeProdutos = produtos.Select(p => p.Codigo).ToList();
            // listaCodigoDeProdutos = produtos.Select(p => p.Codigo).ToList();

            int idDoProduto = 0;
            // int idDoProduto2 = 0;

            foreach (var item in listaDescricaoProdutos)
            {
                // CbbCodProduto.Items.Add(descricao);
                if (descricao == item)
                {
                    idDoProduto = listaDescricaoProdutos.IndexOf(item);
                    idDoProduto2 = produtos[idDoProduto].IdProduto;
                }
            }

            int IndiceProduto = CbbCodProduto.SelectedIndex + 1;

            string IndiceProdutoAsString = Convert.ToString(IndiceProduto);
            // MessageBox.Show("O indice do produto é: " + IndiceProdutoAsString);

            // string qtde = InpQuantidade.Text;
            string qtde = InpTeste.Text;

            int qtde2 = Convert.ToInt32(InpTeste.Text);
            List<Produto> produtos2 = ControllerProduto.Sincronizar();
            listaPrecoDeProdutos2 = produtos.Select(p => p.Preco).ToList();
            decimal precoEmDecimal = listaPrecoDeProdutos2[IndiceProduto];
            decimal TotalDoProduto2 = Convert.ToDecimal(qtde) * precoEmDecimal;

            ControllerProdutosDoPedido.CriarProdutosDoPedido(idDoProduto2, qtde2, TotalDoProduto2);

            Listar(qtde, descricao, idDoProduto2);

            CbbCodProduto.Text = "";
            InpQuantidade.Text = "";
            InpTeste.Text = "";
            MessageBox.Show("Pode adicionar outro produto");
            return;

            // Listar();
        }
        catch (Exception ex)
        {            
            MessageBox.Show("Para adicionar um novo pedido, você deve preencher todos os campos corretamente" + ex);
        }
    }
    private void Listar(string qtde, string descricao, int IndiceProduto) {

        List<Produto> produtos = ControllerProduto.Sincronizar();
        listaPrecoDeProdutos = produtos.Select(p => p.Preco).ToList();

        string precoEmString = Convert.ToString(listaPrecoDeProdutos[IndiceProduto]);
        decimal precoEmDecimal = listaPrecoDeProdutos[IndiceProduto];
        TotalDoProduto = Convert.ToDecimal(qtde) * precoEmDecimal;
        ValorTotal += TotalDoProduto;
        LblTotalValor.Text = Convert.ToString(ValorTotal);
        string totalEmString = Convert.ToString(TotalDoProduto);

        string[] row = new string[] { qtde, descricao, precoEmString, totalEmString };
        DgvProdutos.Rows.Add(row);
    }
    private void CarregarProdutosNoComboBox()
    {
        // Limpa os itens atuais do ComboBox
        CbbCodProduto.Items.Clear();

        // Adiciona os valores da lista ao ComboBox
        List<Produto> produtos = ControllerProduto.Sincronizar();

        listaDescricaoProdutos = produtos.Select(p => p.Descricao).ToList();
        foreach (var descricao in listaDescricaoProdutos)
        {
            CbbCodProduto.Items.Add(descricao);
        }

        // Opcional: Define o primeiro item como selecionado por padrão
        // if (CbbCodProduto.Items.Count > 0)
        // {
        //     CbbCodProduto.SelectedIndex = 0;
        // }
    }

    private void ConfigurarAutoCompleteDoComboBox()
    {
        // Cria uma nova coleção de valores de autocomplete
        var autoCompleteCollection = new AutoCompleteStringCollection();
        autoCompleteCollection.AddRange(listaDescricaoProdutos.ToArray());

        // Configura as propriedades de autocomplete do ComboBox
        CbbCodProduto.AutoCompleteCustomSource = autoCompleteCollection;
    }
}