namespace View;
using System.Drawing;
using Controller;
using Model;

public class ViewNovoPedido : Form {

    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    // private readonly Label LblTotalProdutos;
    // private readonly Label LblTotalProdutosNumber;
    private readonly Label LblSubTitulo;
    private readonly Label LblIdCliente;    
    private readonly TextBox InpIdCliente;
    private readonly Label LblIdFuncionario;    
    private readonly TextBox InpIdFuncionario;
    private readonly Label LblCodProduto;    
    private readonly TextBox InpCodProduto;
    private readonly Label LblQuantidade;    
    private readonly TextBox InpQuantidade;
    private readonly Label LblTotal;    
    private readonly TextBox InpTotal;

    private readonly Button BtnAddProduto;
    private readonly Button BtnFinalizar;
    // private readonly Button BtnDeletar;

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
            Text = "Cód. do Produto",
            Size = new Size(150, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(140, 270),
        };
        InpCodProduto = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 270),
        };
        LblQuantidade = new Label {
            Text = "Quantidade",
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
        LblTotal = new Label {
            Text = "Valor total do pedido:  R$",
            Size = new Size(225, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(250, 650),
        };
        InpTotal = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(480, 650),
        };

       BtnAddProduto = new Button {
            Text = "Adicionar Pod.",
            Location = new Point(450, 270),
            Font = new Font("Arial", 10, FontStyle.Bold),
            Size = new Size(120, 25),
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

        // BtnDeletar = new Button {
        //     Text = "Deletar",
        //     Location = new Point(390, 400),
        //     Font = new Font("Arial", 16, FontStyle.Bold),
        //     Size = new Size(150, 30),
        //     BackColor = Color.Aqua,
        //     TextAlign = ContentAlignment.MiddleCenter,
        // };
        // BtnDeletar.Click += ClickDeletar;
       
        DgvProdutos = new DataGridView {
            Location = new Point(30, 380),
            Size = new Size(550, 250),
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblSubTitulo);
        Controls.Add(LblIdCliente);
        Controls.Add(InpIdCliente);
        Controls.Add(LblIdFuncionario);
        Controls.Add(InpIdFuncionario);
        Controls.Add(LblCodProduto);
        Controls.Add(InpCodProduto);
        Controls.Add(LblQuantidade);
        Controls.Add(InpQuantidade);
        Controls.Add(LblTotal);
        Controls.Add(InpTotal);
        Controls.Add(BtnAddProduto);
        Controls.Add(BtnFinalizar);
        Controls.Add(DgvProdutos);
        // Listar();
    }

    private void ClickFinalizar(object? sender, EventArgs e) {
        if(InpTotal.Text == "") {
            MessageBox.Show("Não há nenhem pedido para salvar");
            return;
        }
        ControllerProduto.CriarProduto(InpIdCliente.Text, InpIdFuncionario.Text, Convert.ToDecimal(InpCodProduto.Text));
        // Listar();
        InpIdCliente.Text = "";
        InpIdFuncionario.Text = "";
        InpCodProduto.Text = "";
        InpQuantidade.Text = "";
    }
    
    private void ClickAddProduto(object? sender, EventArgs e) {
        try
        {
            // InpCodProduto
            // InpQuantidade
            
            // int index = DgvProdutos.SelectedRows[0].Index;
            if(InpIdCliente.Text == "" || InpIdFuncionario.Text == "" || InpCodProduto.Text == "" || InpQuantidade.Text == "") {
                MessageBox.Show("Favor verificar os campos e tentar outra vez");
                return;
            }

            int cliente = Convert.ToInt32(InpIdCliente.Text);
            int funcionario = Convert.ToInt32(InpIdFuncionario.Text);
            int produto = Convert.ToInt32(InpCodProduto.Text);
            int qtde = Convert.ToInt32(InpQuantidade.Text);

            Listar(int cliente, int funcionario, int produto, int qtde);

            





            InpCodProduto.Text = "";
            InpQuantidade.Text = "";
            MessageBox.Show("Pode adicionar outro produto");
            return;


            // ControllerProduto.AdicionarProduto(index, InpIdCliente.Text, InpIdFuncionario.Text, Convert.ToDecimal(InpCodProduto.Text));
            // Listar();
        }
        catch (Exception)
        {            
            MessageBox.Show("Para adicionar um novo pedido, você deve preencher todos os campos corretamente");
        }
    }

    private void Listar(int cliente, int funcionario, int produto, int qtde) {
        List<Produto> produtos = ControllerProduto.ListarProduto();
        DgvProdutos.Columns.Clear();
        DgvProdutos.AutoGenerateColumns = false;
        DgvProdutos.DataSource = produtos;

        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "idProduto",
            HeaderText = "IdProduto",
            Width = 65,
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "descricao",
            HeaderText = "Descrição",
            Width = 200,
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "quantidade",
            HeaderText = "Quantidade",
            Width = 75,
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "preco",
            HeaderText = "Preço",
            Width = 70,
        });
        DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "total",
            HeaderText = "Total",
            Width = 80,
        });
    }

    // private void Listar() {
    //     List<Produto> produtos = ControllerProduto.ListarProduto();
    //     DgvProdutos.Columns.Clear();
    //     DgvProdutos.AutoGenerateColumns = false;
    //     DgvProdutos.DataSource = produtos;

    //     // DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //     //     DataPropertyName = "IdProduto",
    //     //     HeaderText = "Id",
    //     //     Width = 50
    //     // });

    //     DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //         DataPropertyName = "idProduto",
    //         HeaderText = "IdProduto",
    //         Width = 65,
    //     });
    //     DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //         DataPropertyName = "descricao",
    //         HeaderText = "Descrição",
    //         Width = 200,
    //     });
    //     DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //         DataPropertyName = "quantidade",
    //         HeaderText = "Quantidade",
    //         Width = 75,
    //     });
    //     DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //         DataPropertyName = "preco",
    //         HeaderText = "Preço",
    //         Width = 70,
    //     });
    //     DgvProdutos.Columns.Add(new DataGridViewTextBoxColumn {
    //         DataPropertyName = "total",
    //         HeaderText = "Total",
    //         Width = 80,
    //     });
    // }


    // private void ClickDeletar(object? sender, EventArgs e) {
    //     try
    //     {
    //         int index = DgvProdutos.SelectedRows[0].Index;
    //         ControllerProduto.DeletarProduto(index);
    //         Listar();
    //     }
    //     catch (Exception)
    //     {
    //         MessageBox.Show("Para deletar um produto, você deve selecionar a fila completa");
    //     }
    // }
}