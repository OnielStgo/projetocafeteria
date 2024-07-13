namespace View;
using System.Drawing;
using Controller;
using Model;

public class ViewFuncionario : Form {
    private readonly Form ParentForm;
    private readonly Label LblTitulo;
    private readonly Label LblTotalFuncionarios;
    private readonly Label LblTotalFuncionariosNumber;
    private readonly Label LblSubTitulo;
    private readonly Label LblNome;    
    private readonly TextBox InpNome;
    private readonly Label LblIdade;    
    private readonly TextBox InpIdade;
    private readonly Label LblCpf;    
    private readonly TextBox InpCpf;
    private readonly Label LblTelefone;    
    private readonly TextBox InpTelefone;
    private readonly Button BtnCadastrar;
    private readonly Button BtnAlterar;
    private readonly Button BtnDeletar;
    private readonly DataGridView DgvFuncionarios;

    public ViewFuncionario(Form parent) {
        ControllerFuncionario.Sincronizar();
        ParentForm = parent;
        Size = new Size(650, 800);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Blue;

        LblTitulo = new Label {
            Text = "FUNCIONÁRIOS",
            Size = new Size(500, 30),
            Font = new Font("Arial", 24, FontStyle.Bold),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(50, 10),
        };
        LblTotalFuncionarios = new Label {
            Text = "Número total de funcionários:",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 100),
        };
        LblTotalFuncionariosNumber = new Label {
            Text = "",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(360, 100),
        };
        LblSubTitulo = new Label {
            Text = "A seguir campos para cadastrar ou alterar um funcionário",
            AutoSize = true,
            Font = new Font("Arial", 16, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(30, 150),
        };
        LblNome = new Label {
            Text = "Nome",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 200),
        };
        InpNome = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 200),
        };
        LblIdade = new Label {
            Text = "Idade",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 250),
        };
        InpIdade = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 250),
        };
        LblCpf = new Label {
            Text = "CPF",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 300),
        };
        InpCpf = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 300),
        };
        LblTelefone = new Label {
            Text = "Telefone",
            Size = new Size(95, 24),
            Font = new Font("Arial", 13, FontStyle.Bold),
            BackColor = Color.Aqua,
            Location = new Point(195, 350),
        };
        InpTelefone = new TextBox {
            Size = new Size(100, 80),
            BackColor = Color.Aqua,
            Location = new Point(300, 350),
        };
        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 450),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnCadastrar.Click += ClickCadastrar;

        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(220, 450),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnAlterar.Click += ClickAlterar;

        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(390, 450),
            Font = new Font("Arial", 16, FontStyle.Bold),
            Size = new Size(150, 30),
            BackColor = Color.Aqua,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        BtnDeletar.Click += ClickDeletar;
       
        DgvFuncionarios = new DataGridView {
            Location = new Point(30, 500),
            Size = new Size(550, 250),
        };

        Controls.Add(LblTitulo);
        Controls.Add(LblTotalFuncionarios);
        Controls.Add(LblTotalFuncionariosNumber);
        Controls.Add(LblSubTitulo);
        Controls.Add(LblNome);
        Controls.Add(InpNome);
        Controls.Add(LblIdade);
        Controls.Add(InpIdade);
        Controls.Add(LblCpf);
        Controls.Add(InpCpf);
        Controls.Add(LblTelefone);
        Controls.Add(InpTelefone);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDeletar);
        Controls.Add(DgvFuncionarios);
        Listar();
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpNome.Text == "") {
            return;
        }
        ControllerFuncionario.CriarFuncionario(InpNome.Text, InpIdade.Text, InpCpf.Text, InpTelefone.Text);
        Listar();
        InpNome.Text = "";
        InpIdade.Text = "";
        InpCpf.Text = "";
        InpTelefone.Text = "";
    }
    
    private void ClickAlterar(object? sender, EventArgs e) {
        try
        {
            int index = DgvFuncionarios.SelectedRows[0].Index;
            if(InpNome.Text == "") {
                return;
            }
            ControllerFuncionario.AlterarFuncionario(index, InpNome.Text, InpIdade.Text, InpCpf.Text, InpTelefone.Text);
            Listar();
        }
        catch (Exception)
        {            
            MessageBox.Show("Para alterar os dados de um funcionário, você deve preencher todos os campos corretamente");
        }
    }

    private void Listar() {
        List<Funcionario> funcionarios = ControllerFuncionario.ListarFuncionario();
        LblTotalFuncionariosNumber.Text = Convert.ToString(funcionarios.Count);
        DgvFuncionarios.Columns.Clear();
        DgvFuncionarios.AutoGenerateColumns = false;
        DgvFuncionarios.DataSource = funcionarios;

        DgvFuncionarios.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "IdFuncionario",
            HeaderText = "Id",
            Width = 40
        });
        DgvFuncionarios.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "nome",
            HeaderText = "Nome",
            Width = 150
        });
        DgvFuncionarios.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "idade",
            HeaderText = "Idade",
            Width = 60
        });
        DgvFuncionarios.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "cpf",
            HeaderText = "CPF",
            Width = 120

        });
        DgvFuncionarios.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "telefone",
            HeaderText = "Telefone",
            Width = 120
        });
    }
    private void ClickDeletar(object? sender, EventArgs e) {
        try
        {
            int index = DgvFuncionarios.SelectedRows[0].Index;
            ControllerFuncionario.DeletarFuncionario(index);
            Listar();
        }
        catch (Exception)
        {
            MessageBox.Show("Para deletar um funcionário, você deve selecionar a fila completa");
        }
    }
}